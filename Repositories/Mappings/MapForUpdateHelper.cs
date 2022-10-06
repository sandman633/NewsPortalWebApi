using DAL.Dto;

namespace Repositories.Mappings
{
    public static class MapForUpdateHelper
    {
        public static NewsDto NewsUpdateMap(NewsDto newsForUpdate, NewsDto originalNews)
        {
            originalNews.Header = newsForUpdate.Header ?? originalNews.Header;
            originalNews.Body = newsForUpdate.Body ?? originalNews.Body;
            return originalNews;
        }
        public static CommentsDto CommentUpdateMap(CommentsDto commentsForUpdate, CommentsDto originalComments)
        {
            
            originalComments.Text = commentsForUpdate.Text ?? originalComments.Text;
            return originalComments;
        }
        public static UserDto CommentUpdateMap(UserDto userForUpdate, UserDto originalUser)
        {
            originalUser.Email = userForUpdate.Email ?? originalUser.Email;
            originalUser.Name = userForUpdate.Name ?? originalUser.Name;
            originalUser.Surname = userForUpdate.Surname ?? originalUser.Surname;
            originalUser.Age = userForUpdate.Age ?? originalUser.Age;
            return originalUser;
        }
    }
}
