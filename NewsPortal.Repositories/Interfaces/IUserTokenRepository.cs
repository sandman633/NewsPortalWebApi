using NewsPortal.Model.Domain;
using Repositories.Interfaces.CRUD;

namespace Repositories.Interfaces
{
    public interface IUserTokenRepository : ICrudRepository<UserToken>
    {
    }
}
