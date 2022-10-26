using Model.Domain;
using System.Collections.Generic;

namespace TestWebApi.Infrastructure.Helpers.DbHelpers
{
    public static class GroupPolicyHelper
    {
        public static GroupPolicy GetOne(int id,string policyType,short policyValue)
        {
            return new GroupPolicy
            {
                Id = id,
                GroupId = 1,
                PolicyType = policyType,
                PolicyValue = policyValue,
            };
        }
        public static IEnumerable<GroupPolicy> GetMany(IEnumerable<KeyValuePair<string, short>> groupsPoliciesIdies)
        {
            int id = 1;
            foreach (KeyValuePair<string, short> groupPolicy in groupsPoliciesIdies)
            {
                yield return GetOne(id, groupPolicy.Key, groupPolicy.Value);
                id++;
            }
        }
    }
}
