using NewsPortal.Model.Domain;
using System.Collections.Generic;

namespace NewsPortal.Tests.Infrastructure.Helpers.DbHelpers
{
    public static class NewsHelper
    {
        public static News GetOne(int id = 1)
        {
            return new News
            {
                Id = id,
                Title = $"Title {id}",
                Text = $"Text {id}",
                CreatedTime = System.DateTime.Now,
                UserId = id
            };
        }
        public static IEnumerable<News> GetMany(int count = 1)
        {
            for (int i = 1; i <= count; i++)
            {
                yield return GetOne(i);
            }
        }
    }
}
