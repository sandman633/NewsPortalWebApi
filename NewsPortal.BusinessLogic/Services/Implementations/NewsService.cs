using NewsPortal.BusinessLogic.Services.Interfaces;
using NewsPortal.Model.Domain;
using NewsPortal.DAL.Dto;
using Repositories.Interfaces;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using NewsPortal.BusinessLogic.Services.Infrastructure;
using NewsPortal.Model;
using AutoMapper;

namespace NewsPortal.BusinessLogic.Services.Implementations
{
    public class NewsService : BaseService<NewsDto, News, INewsRepository>, INewsService
    {
        public NewsService(IUnitOfWork<WebApiContext> unitOfWork,IMapper mapper) : base(unitOfWork,mapper)
        {
            
        }

        public async Task<IEnumerable<NewsDto>> GetNewsByUser(int userId)
        {
            return _mapper.Map<IEnumerable<NewsDto>>(await _crudRepository.GetByCriteriaAsync(c => c.UserId == userId));
        }
        public override async Task<NewsDto> UpdateAsync(NewsDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            var originalEntity = await GetByIdAsync(dto.Id);
            if (originalEntity == null) throw new NullReferenceException(nameof(originalEntity)); 
            originalEntity = MapForUpdateHelper.NewsUpdateMap(dto, originalEntity);
            return await base.UpdateAsync(originalEntity);
        }
    }
}
