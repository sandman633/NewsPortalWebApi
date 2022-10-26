using AutoMapper;
using Model.Domain;
using Microsoft.EntityFrameworkCore;
using DAL.Dto;
using Repositories.Interfaces.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Model;

namespace Repositories
{
    /// <summary>
    /// Base class of repository.
    /// </summary>
    /// <typeparam name="TDto">TDto.</typeparam>
    /// <typeparam name="TModel">TModel.</typeparam>
    public class BaseRepository<TDto, TModel> : ICrudRepository<TDto, TModel>
        where TDto : BaseDto
        where TModel : BaseEntity
    {
        protected readonly WebApiContext _context;
        protected readonly IMapper _mapper;
        protected DbSet<TModel> DbSet => _context.Set<TModel>();

        /// <summary>
        /// Initializes the instance <see cref="BaseRepository{TDto, TEntity}"/>.
        /// </summary>
        public BaseRepository(WebApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Asynchronous method for creating entity.
        /// </summary>
        /// <param name="dto">DTO.</param>
        /// <returns>ID of the created entity.</returns>
        public virtual async Task<TDto> CreateAsync(TDto dto)
        {
            var entity = _mapper.Map<TModel>(dto);
            await DbSet.AddAsync(entity);
            return await GetByIdAsync(entity.Id);
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
        public virtual async Task<IEnumerable<TDto>> GetAsync()
        {
            var entity = await DefaultIncludeProperties(DbSet).AsNoTracking().ToListAsync();
            var dtos = _mapper.Map<IEnumerable<TDto>>(entity);
            return dtos;
        }
        /// <summary>
        /// Returns all entities that match the given filter.
        /// </summary>
        /// <param name="filter">Search criteria.</param>
        public virtual async Task<IEnumerable<TDto>> GetByCriteriaAsync(Expression<Func<TModel, bool>> filter = null)
        {
            IQueryable<TModel> entities = DefaultIncludeProperties(DbSet).AsNoTracking();
            if (filter != null)
                entities = entities.Where(filter);
            var dtos = _mapper.Map<IEnumerable<TDto>>(await entities.ToListAsync());
            return dtos;
        }

        /// <summary>
        /// Asynchronous method for getting entity by id.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <returns>DTO.</returns>
        public virtual async Task<TDto> GetByIdAsync(int id)
        {
            var entities = await DefaultIncludeProperties(DbSet)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            var tdos = _mapper.Map<TDto>(entities);
            return tdos;
        }

        /// <summary>
        /// Asynchronous method for updating entity.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>DTO.</returns>
        public virtual async Task<TDto> UpdateAsync(TDto dto)
        {

            var entity = _mapper.Map<TModel>(dto);
            //if (!DbSet.Contains(entity))
            //throw new ex
            DbSet.Update(entity);
            var newEntity = await GetByIdAsync(entity.Id);
            return _mapper.Map<TDto>(newEntity);
        }

        public virtual async Task UpdateRangeAsync(IEnumerable<TDto> dtoes)
        {
            var entites = _mapper.Map<IEnumerable<TModel>>(dtoes);
            DbSet.UpdateRange(entites);
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


    }
}
