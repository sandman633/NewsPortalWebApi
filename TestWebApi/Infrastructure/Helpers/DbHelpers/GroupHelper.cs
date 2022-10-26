using Model.Domain;
using System.Collections.Generic;

namespace TestWebApi.Infrastructure.Helpers.DbHelpers
{
    public static class GroupHelper
    {
        public static Group GetOne(string description,int id = 1)
        {
            return new Group
            {
                Id = id,
                GroupName = description,
            };
        }
        public static IEnumerable<Group> GetMany(IDictionary<int,string> groups)
        {
            foreach(var group in groups)
                yield return GetOne(group.Value, group.Key);
        }
    }

}
