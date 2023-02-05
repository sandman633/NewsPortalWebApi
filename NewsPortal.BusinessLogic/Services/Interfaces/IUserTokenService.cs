using NewsPortal.BusinessLogic.Services.Interfaces.CRUD;
using NewsPortal.DAL.Dto;
using System;
using System.Threading.Tasks;

namespace NewsPortal.BusinessLogic.Services.Interfaces
{
    public interface IUserTokenService : ICrudService<UserTokenDto>
    {
        Task AddRefreshToken(int userId, string jwtRefreshToken, DateTime refreshTime);
    }
}
