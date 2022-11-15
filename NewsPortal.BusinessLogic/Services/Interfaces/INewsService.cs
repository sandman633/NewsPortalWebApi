using NewsPortal.BusinessLogic.Services.Interfaces.CRUD;
using NewsPortal.DAL.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsPortal.BusinessLogic.Services.Interfaces
{
    public interface INewsService : ICrudService<NewsDto>
    {
        Task<IEnumerable<NewsDto>> GetNewsByUser(int userId);
    }
}
