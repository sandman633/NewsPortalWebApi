using BL.Services.Interfaces;
using Model.Domain;
using DAL.Dto;
using Repositories.Interfaces;

namespace BL.Services.Implementations
{
    public class GroupService : BaseService<GroupDto, Group>, IGroupService
    {
        public GroupService(IGroupRepository crudRepository) : base(crudRepository)
        {

        }

    }
}
