using NewsPortal.BusinessLogic.Services.Interfaces;
using Model.Domain;
using NewsPortal.DAL.Dto;
using Repositories.Interfaces;
using Model;

namespace NewsPortal.BusinessLogic.Services.Implementations
{
    public class GroupService : BaseService<GroupDto, Group, IGroupRepository>, IGroupService
    {
        public GroupService(IUnitOfWork<WebApiContext> unitOfWork) : base(unitOfWork)
        {

        }

    }
}
