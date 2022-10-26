using Model.Domain;
using System.Collections.Generic;

namespace TestWebApi.Infrastructure.Helpers.DbHelpers
{
    public static class GroupHelper
    {
        public static Group GetOne(int id = 1)
        {
            return new Group
            {
                Id = id,
                GroupName = $"Group {id}",
            };
        }
        public static IEnumerable<Group> GetMany(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                yield return GetOne(i);
            }
        }
    }

}
