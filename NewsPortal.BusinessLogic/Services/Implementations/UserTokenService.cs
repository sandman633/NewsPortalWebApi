using NewsPortal.BusinessLogic.Services.Interfaces;
using NewsPortal.Model.Domain;
using NewsPortal.DAL.Dto;
using Repositories.Interfaces;
using System.Threading.Tasks;
using System;
using NewsPortal.Model;
using AutoMapper;

namespace NewsPortal.BusinessLogic.Services.Implementations
{
    public class UserTokenService : BaseService<UserTokenDto, UserToken, IUserTokenRepository>, IUserTokenService
    {
        public UserTokenService(IUnitOfWork<WebApiContext> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task AddRefreshToken(int userId, string jwtRefreshToken, DateTime refreshTime)
        {
            var user = new UserToken()
            {
                UserId = userId,
                RefreshToken = jwtRefreshToken,
                ExpireDate = refreshTime
            };
            await _crudRepository.CreateAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }

}
