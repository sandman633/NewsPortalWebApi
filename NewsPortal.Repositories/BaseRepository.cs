using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NewsPortal.DAL.Dto;
using NewsPortal.Model;
using NewsPortal.Model.Domain;
using NewsPortal.Repositories.Infrastructure.Exceptions;
using Repositories.Interfaces.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositories
{
    /// <summary>
    /// Base class of repository.
    /// </summary>
    /// <typeparam name="TDto">TDto.</typeparam>
    /// <typeparam name="TModel">TModel.</typeparam>
    public class BaseRepository<TDto, TModel> : ICrudRepository<TModel>
        where TDto : BaseDto
        where TModel : BaseEntity
    {
        protected readonly WebApiContext _context;
        protected DbSet<TModel> DbSet => _context.Set<TModel>();

        /// <summary>
        /// Initializes the instance <see cref="BaseRepository{TDto, TEntity}"/>.
        /// </summary>
        public BaseRepository(WebApiContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Asynchronous method for creating entity.
        /// </summary>
        /// <param name="dto">DTO.</param>
        /// <returns>ID of the created entity.</returns>
        public virtual async Task<TModel> CreateAsync(TModel entity)
        {
            await DbSet.AddAsync(entity);
            return entity;
        }

        /// <summary>
        /// Asynchronous method for deleting entity.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>A task that represents an asynchronous operation.</returns>
        public virtual async Task DeleteAsync(params int[] ids)
        {
            var entities = await DbSet.Where(x => ids.Contains(x.Id)).ToListAsync();
            DbSet.RemoveRange(entities);
        }
        /// <summary>
        /// Asynchronous method for getting entity.
        /// </summary>
        /// <returns>DTO collection.</returns>
        public virtual async Task<IEnumerable<TModel>> GetAsync()
        {
            var entity = await DefaultIncludeProperties(DbSet).AsNoTracking().ToListAsync();
            return entity;
        }
        /// <summary>
        /// Returns all entities that match the given filter.
        /// </summary>
        /// <param name="filter">Search criteria.</param>
        public virtual async Task<IEnumerable<TModel>> GetByCriteriaAsync(Expression<Func<TModel, bool>> filter = null)
        {
            IQueryable<TModel> entities = DefaultIncludeProperties(DbSet).AsNoTracking();
            if (filter != null)
                entities = entities.Where(filter);
            return entities;
        }

        /// <summary>
        /// Asynchronous method for getting entity by id.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <returns>DTO.</returns>
        public virtual async Task<TModel> GetByIdAsync(int id)
        {
            try
            {
                var entity = await DefaultIncludeProperties(DbSet)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (entity == null)
                    throw new DataTransactionException($"Entity { typeof(TModel).Name } with Id : {id} not found", new { Id = id }, 404);
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Asynchronous method for updating entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>DTO.</returns>
        public virtual async Task UpdateAsync(TModel entity)
        {
            DbSet.Update(entity);
        }

        public virtual async Task UpdateRangeAsync(IEnumerable<TModel> entities)
        {
            DbSet.UpdateRange(entities);
        }
        public virtual  void SaveChanges()
        {
            _context.SaveChanges();
        }
        /// <summary>
        /// Method for loading related data.
        /// </summary>
        /// <param name="dbSet">DbSet.</param>
        /// <returns>DbSet.</returns>
        public virtual IQueryable<TModel> DefaultIncludeProperties(DbSet<TModel> dbSet) => dbSet;
        public async Task<TModel> GetByIdAsyncWithTracking(int id)
        {
            try
            {
                var entity = await DefaultIncludeProperties(DbSet)
                    .FirstOrDefaultAsync(x => x.Id == id);
                if (entity == null)
                    throw new DataTransactionException($"Entity {typeof(TModel).Name} with Id : {id} not found", new { Id = id }, 404);
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
