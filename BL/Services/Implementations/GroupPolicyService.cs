using BL.Services.Interfaces;
using Model.Domain;
using DAL.Dto;
using Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repositories.Mappings;
using System;

namespace BL.Services.Implementations
{
    public class GroupPolicyService : BaseService<GroupPolicyDto, GroupPolicy>, IGroupPolicyService
    {
        public GroupPolicyService(IGroupPolicyRepository crudRepository) : base(crudRepository)
        {

        }
        public override async Task<GroupPolicyDto> UpdateAsync(GroupPolicyDto dto)
        {
            var groupPolicy = await _crudRepository.GetByIdAsync(dto.Id);
            if (groupPolicy == null)
                throw new NullReferenceException();
            groupPolicy = MapForUpdateHelper.GroupPolicyUpdateMap(dto, groupPolicy);
            return await base.UpdateAsync(groupPolicy);
        }
        public async Task<Dictionary<string, short?>> GetPolicies(int groupId)
        {
            var groupPolicy = await _crudRepository.GetByCriteriaAsync(u => u.GroupId == groupId);
            return groupPolicy.Select(u => KeyValuePair.Create<string, short?>(u.PolicyType, u.PolicyValue)).ToDictionary(kpv => kpv.Key, kpv => kpv.Value);
        }
        public async Task<Dictionary<string, short?>> GetPoliciesForUser(int userId)
        {
            var userPolicy = await _crudRepository.GetByCriteriaAsync(u => u.Group.UserGroups.Select(x=>x.UserId).Contains(userId));
            Dictionary<string,short?> result = new Dictionary<string,short?>();
            foreach(var groupPolicy in userPolicy)
            {
                if(!result.TryAdd(groupPolicy.PolicyType, groupPolicy.PolicyValue))
                {
                    result[groupPolicy.PolicyType] = (short?)((Permissions)result[groupPolicy.PolicyType].Value | (Permissions)groupPolicy.PolicyValue);
                }
            }
            return result;
        }
    }
}
