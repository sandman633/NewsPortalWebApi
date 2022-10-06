using Bl.Services.Interfaces.CRUD;
using DAL.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Services.Interfaces
{
    public interface INewsService : ICrudService<NewsDto>
    {
        Task<IEnumerable<NewsDto>> GetNewsByUser(int userId);
    }
}
