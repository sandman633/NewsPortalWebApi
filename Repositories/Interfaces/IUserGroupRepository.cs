using Model.Domain;
using DAL.Dto;
using Repositories.Interfaces.CRUD;

namespace Repositories.Interfaces
{
    public interface IUserGroupRepository : ICrudRepository<UserGroupDto, UserGroup>
    {
    }
}
