using NewsPortal.Model.Domain;
using System.Collections.Generic;

namespace TestWebApi.Infrastructure.Helpers.DbHelpers
{
    public static class GroupPolicyHelper
    {
        public static GroupPolicy GetOne(int id,int groupId,string policyType,short policyValue)
        {
            return new GroupPolicy
            {
                Id = id,
                GroupId = 1,
                PolicyType = policyType,
                PolicyValue = policyValue,
            };
        }
        public static IEnumerable<GroupPolicy> GetMany(Dictionary<int,IEnumerable<KeyValuePair<string, short>>> groupsPoliciesIdies)
        {
            int id = 1;
            foreach (var groupPolicies in groupsPoliciesIdies)
            {
                foreach(var groupPolicy in groupPolicies.Value)
                {
                    yield return GetOne(id, groupPolicies.Key, groupPolicy.Key, groupPolicy.Value);
                    id++;
                }
            }
        }
    }
}
