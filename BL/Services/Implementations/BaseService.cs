using Model.Domain;
using DAL.Dto;
using Bl.Services.Interfaces.CRUD;
using System.Collections.Generic;
using Repositories.Interfaces.CRUD;
using System.Threading.Tasks;

namespace BL.Services.Implementations
{
    public class BaseService<TDto, TEntity> : ICrudService<TDto>
            where TDto : BaseDto
            where TEntity : BaseEntity
    {
        protected readonly ICrudRepository<TDto, TEntity> _crudRepository;


        public BaseService(ICrudRepository<TDto, TEntity> crudRepository)
        {

            _crudRepository = crudRepository;
        }

        /// <summary>
        ///     Asynchronous method for creating entity.
        /// </summary>
        /// <param name="dto"></param>
        public virtual async Task<TDto> CreateAsync(TDto dto)
        {
            var entity = await _crudRepository.CreateAsync(dto);

            return entity;
        }

        /// <summary>
        ///     Asynchronous method for deleting entity.
        /// </summary>
        /// <param name="ids"></param>
        public virtual async Task DeleteAsync(params int[] ids)
        {
            await _crudRepository.DeleteAsync(ids);

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
            return updatedEntity;
        }
    }
}
