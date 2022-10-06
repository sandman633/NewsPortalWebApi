using BL.Services.Interfaces;
using Model.Domain;
using DAL.Dto;
using Repositories.Interfaces;
using System.Threading.Tasks;
using System;
using Repositories.Mappings;
using System.Collections.Generic;

namespace BL.Services.Implementations
{
    public class NewsService : BaseService<NewsDto, News>, INewsService
    {
        public NewsService(INewsRepository crudRepository) : base(crudRepository)
        {
        }

        public async Task<IEnumerable<NewsDto>> GetNewsByUser(int userId)
        {
            return await _crudRepository.GetByCriteriaAsync(c => c.UserId == userId);
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
