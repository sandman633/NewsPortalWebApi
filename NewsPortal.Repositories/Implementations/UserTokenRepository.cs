using NewsPortal.Model.Domain;
using NewsPortal.DAL.Dto;
using Repositories.Interfaces;
using NewsPortal.Model;

namespace Repositories.Implementations
{
    public class UserTokenRepository : BaseRepository<UserTokenDto, UserToken>, IUserTokenRepository
    {
        public UserTokenRepository(WebApiContext context) : base(context)
        {

        }

    }
}
