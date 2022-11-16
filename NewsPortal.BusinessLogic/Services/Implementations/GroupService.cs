using NewsPortal.BusinessLogic.Services.Interfaces;
using NewsPortal.Model.Domain;
using NewsPortal.DAL.Dto;
using Repositories.Interfaces;
using NewsPortal.Model;
using AutoMapper;

namespace NewsPortal.BusinessLogic.Services.Implementations
{
    public class GroupService : BaseService<GroupDto, Group, IGroupRepository>, IGroupService
    {
        public GroupService(IUnitOfWork<WebApiContext> unitOfWork,IMapper mapper) : base(unitOfWork, mapper)
        {

        }

    }
}
