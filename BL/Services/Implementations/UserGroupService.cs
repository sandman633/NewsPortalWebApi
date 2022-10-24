using BL.Services.Interfaces;
using Model.Domain;
using DAL.Dto;
using Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Services.Implementations
{
    public class UserGroupService : BaseService<UserGroupDto, UserGroup>, IUserGroupService
    {
        public UserGroupService(IUserGroupRepository crudRepository) : base(crudRepository)
        {

        }
        public async Task<Dictionary<int, string>> GetGroups(int userId)
        {
            var userPolicy  = await _crudRepository.GetByCriteriaAsync(u => u.UserId == userId);
            return userPolicy.Select(u => KeyValuePair.Create<int, string>(u.GroupId,u.Group.GroupName)).ToDictionary(kpv=>kpv.Key,kpv=>kpv.Value);
        }
    }
}
