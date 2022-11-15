using NewsPortal.DAL.Dto;

namespace NewsPortal.BusinessLogic.Services.Infrastructure
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
        public static UserDto UserUpdateMap(UserDto userForUpdate, UserDto originalUser)
        {
            originalUser.Email = userForUpdate.Email ?? originalUser.Email;
            originalUser.Name = userForUpdate.Name ?? originalUser.Name;
            originalUser.Surname = userForUpdate.Surname ?? originalUser.Surname;
            originalUser.Age = userForUpdate.Age ?? originalUser.Age;
            return originalUser;
        }
        public static GroupPolicyDto GroupPolicyUpdateMap(GroupPolicyDto groupPolicyForUpdate, GroupPolicyDto originalGroupPolicy)
        {
            originalGroupPolicy.GroupId = groupPolicyForUpdate.GroupId ?? originalGroupPolicy.GroupId;
            originalGroupPolicy.PolicyType = groupPolicyForUpdate.PolicyType ?? originalGroupPolicy.PolicyType;
            originalGroupPolicy.PolicyValue = groupPolicyForUpdate.PolicyValue ?? originalGroupPolicy.PolicyValue;
            originalGroupPolicy.Group = null;
            return originalGroupPolicy;
        }
    }
}
