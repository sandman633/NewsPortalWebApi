using Model.Domain;
using DAL.Dto;
using Repositories.Interfaces.CRUD;

namespace Repositories.Interfaces
{
    public interface IGroupRepository : ICrudRepository<GroupDto, Group>
    {
    }
}
