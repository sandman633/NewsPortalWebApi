using NewsPortal.Model.Domain;
using System.Collections.Generic;

namespace NewsPortal.Tests.Infrastructure.Helpers.DbHelpers
{
    public static class CommentsHelper
    {
        public static Comments GetOne(int id = 1)
        {
            return new Comments
            {
                Id = id,
                CommentState = CommentState.NOTDELETED,
                Text = $"Text {id}",
                CreatedTime = System.DateTime.Now,
                Root = 0,
                UserId = id,
                NewsId = id,
            };
        }
        public static IEnumerable<Comments> GetMany(int count = 1)
        {
            for (int i = 1; i <= count; i++)
            {
                yield return GetOne(i);
            }
        }
    }
}
