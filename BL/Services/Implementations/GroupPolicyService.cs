﻿using BL.Services.Interfaces;
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
        public async Task<IEnumerable<KeyValuePair<string, short?>>> GetPolicies(int groupId)
        {
            var groupPolicy = await _crudRepository.GetByCriteriaAsync(u => u.GroupId == groupId);
            return groupPolicy.Select(u => KeyValuePair.Create<string, short?>(u.PolicyType, u.PolicyValue));
        }
        public async Task<IEnumerable<KeyValuePair<string, short?>>> GetPoliciesForUser(int userId)
        {
            var userPolicy = await _crudRepository.GetByCriteriaAsync(u => u.Group.UserGroups.Select(x=>x.UserId).Contains(userId));
            return userPolicy.Select(u => KeyValuePair.Create<string, short?>(u.PolicyType, u.PolicyValue));
        }
    }
}