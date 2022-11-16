using NewsPortal.Model.Domain;
using NewsPortal.DAL.Dto;
using NewsPortal.BusinessLogic.Services.Interfaces.CRUD;
using System.Collections.Generic;
using Repositories.Interfaces.CRUD;
using System.Threading.Tasks;
using Repositories.Interfaces;
using NewsPortal.Model;
using AutoMapper;

namespace NewsPortal.BusinessLogic.Services.Implementations
{
    public class BaseService<TDto, TEntity,TRepositoryType> : ICrudService<TDto>
            where TDto : BaseDto
            where TEntity : BaseEntity
            where TRepositoryType : class,ICrudRepository<TEntity>
    {
        protected readonly ICrudRepository<TEntity> _crudRepository;
        protected readonly IUnitOfWork<WebApiContext> _unitOfWork;
        protected readonly IMapper _mapper;

        public BaseService(IUnitOfWork<WebApiContext> unitOfWork, IMapper mapper)
        {
            _crudRepository =  unitOfWork.GetRepository<TEntity, TRepositoryType>();
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        ///     Asynchronous method for creating entity.
        /// </summary>
        /// <param name="dto"></param>
        public virtual async Task<TDto> CreateAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            var result = await _crudRepository.CreateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TDto>(result);
        }

        /// <summary>
        ///     Asynchronous method for deleting entity.
        /// </summary>
        /// <param name="ids"></param>
        public virtual async Task DeleteAsync(params int[] ids)
        {
            await _crudRepository.DeleteAsync(ids);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        ///     Asynchronous method for getting entity.
        /// </summary>
        public virtual async Task<IEnumerable<TDto>> GetAsync()
        {
            return _mapper.Map<IEnumerable<TDto>>(await _crudRepository.GetAsync());
        }

        /// <summary>
        ///     Asynchronous method for getting entity by id.
        /// </summary>
        /// <param name="id"></param>
        public virtual async Task<TDto> GetByIdAsync(int id)
        {
            var entity = _mapper.Map<TDto>(await _crudRepository.GetByIdAsync(id));
            return entity;
        }

        public virtual async Task<TDto> GetByIdAsyncWithTracking(int id)
        {
            var entity = _mapper.Map<TDto>(await _crudRepository.GetByIdAsyncWithTracking(id));
            return entity;
        }

        /// <summary>
        ///     Asynchronous method for updating entity.
        /// </summary>
        /// <param name="dto"></param>
        public virtual async Task<TDto> UpdateAsync(TDto dto)
        {
            await _crudRepository.UpdateAsync(_mapper.Map<TEntity>(dto));
            await _unitOfWork.SaveChangesAsync();
            var updatedEntity = await _crudRepository.GetByIdAsync(dto.Id);
            return _mapper.Map<TDto>(updatedEntity);
        }
    }
}
