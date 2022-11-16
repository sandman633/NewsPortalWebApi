using NewsPortal.BusinessLogic.Services.Interfaces;
using NewsPortal.Model.Domain;
using NewsPortal.DAL.Dto;
using Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsPortal.Model;
using AutoMapper;

namespace NewsPortal.BusinessLogic.Services.Implementations
{
    public class UserGroupService : BaseService<UserGroupDto, UserGroup, IUserGroupRepository>, IUserGroupService
    {
        public UserGroupService(IUnitOfWork<WebApiContext> unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
        public async Task<Dictionary<int, string>> GetGroups(int userId)
        {
            var userPolicy  = await _crudRepository.GetByCriteriaAsync(u => u.UserId == userId);
            return userPolicy.Select(u => KeyValuePair.Create<int, string>(u.GroupId,u.Group.GroupName)).ToDictionary(kpv=>kpv.Key,kpv=>kpv.Value);
        }
    }
}
