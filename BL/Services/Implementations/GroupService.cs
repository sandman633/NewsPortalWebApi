using BL.Services.Interfaces;
using Model.Domain;
using DAL.Dto;
using Repositories.Interfaces;
using Model;

namespace BL.Services.Implementations
{
    public class GroupService : BaseService<GroupDto, Group, IGroupRepository>, IGroupService
    {
        public GroupService(IUnitOfWork<WebApiContext> unitOfWork) : base(unitOfWork)
        {

        }

    }
}
