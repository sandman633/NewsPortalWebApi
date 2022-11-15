using Model.Domain;
using NewsPortal.DAL.Dto;
using NewsPortal.BusinessLogic.Services.Interfaces.CRUD;
using System.Collections.Generic;
using Repositories.Interfaces.CRUD;
using System.Threading.Tasks;
using Repositories.Interfaces;
using Model;
using System;

namespace NewsPortal.BusinessLogic.Services.Implementations
{
    public class BaseService<TDto, TEntity,TRepositoryType> : ICrudService<TDto>
            where TDto : BaseDto
            where TEntity : BaseEntity
            where TRepositoryType : class,ICrudRepository<TDto, TEntity>
    {
        protected readonly ICrudRepository<TDto, TEntity> _crudRepository;
        protected readonly IUnitOfWork<WebApiContext> _unitOfWork;


        public BaseService(IUnitOfWork<WebApiContext> unitOfWork)
        {
            _crudRepository =  unitOfWork.GetRepository<TDto, TEntity, TRepositoryType>();
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        ///     Asynchronous method for creating entity.
        /// </summary>
        /// <param name="dto"></param>
        public virtual async Task<TDto> CreateAsync(TDto dto)
        {
            var entity = await _crudRepository.CreateAsync(dto);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        ///     Asynchronous method for deleting entity.
        /// </summary>
        /// <param name="ids"></param>
        public virtual async Task DeleteAsync(params int[] ids)
        {
            await _crudRepository.DeleteAsync(ids);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        ///     Asynchronous method for getting entity.
        /// </summary>
        public virtual async Task<IEnumerable<TDto>> GetAsync()
        {
            return await _crudRepository.GetAsync();
        }

        /// <summary>
        ///     Asynchronous method for getting entity by id.
        /// </summary>
        /// <param name="id"></param>
        public virtual async Task<TDto> GetByIdAsync(int id)
        {
            return await _crudRepository.GetByIdAsync(id);
        }

        /// <summary>
        ///     Asynchronous method for updating entity.
        /// </summary>
        /// <param name="dto"></param>
        public virtual async Task<TDto> UpdateAsync(TDto dto)
        {
            var updatedEntity = await _crudRepository.UpdateAsync(dto);
            await _unitOfWork.SaveChangesAsync();
            return updatedEntity;
        }
    }
}
