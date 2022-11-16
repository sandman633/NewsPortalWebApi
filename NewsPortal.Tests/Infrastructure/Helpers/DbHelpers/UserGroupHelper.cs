using NewsPortal.Model.Domain;
using System.Collections.Generic;

namespace NewsPortal.Tests.Infrastructure.Helpers.DbHelpers
{
    public static class UserGroupHelper
    {
        public static UserGroup GetOne(int id = 1,int groupId = 1, int userId = 1)
        {
            return new UserGroup
            {
                Id = id,
                GroupId= groupId,
                UserId=userId,
            };
        }
        public static IEnumerable<UserGroup> GetMany(IEnumerable<KeyValuePair<int, int>> userGroupsIdies)
        {
            int id = 1;
            foreach(KeyValuePair<int, int> userGroup in userGroupsIdies)
            {
                yield return GetOne(id,userGroup.Key,userGroup.Value);
                id++;
            }
        }
    }
}
