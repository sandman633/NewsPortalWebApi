using NewsPortal.Model.Domain;
using NewsPortal.DAL.Dto;
using Repositories.Interfaces.CRUD;

namespace Repositories.Interfaces
{
    public interface IUserGroupRepository : ICrudRepository<UserGroupDto, UserGroup>
    {
    }
}
