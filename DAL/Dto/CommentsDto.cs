
namespace DAL.Dto
{
    /// <summary>
    /// CommentsDto.
    /// </summary>
    public class CommentsDto : BaseDto
    {
        /// <summary>
        /// Userdto.
        /// </summary>

        public UserDto User { get; set; }
        /// <summary>
        /// UserId.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Root-level. Describes the nesting level.
        /// </summary>
        public int Root { get; set; }
        /// <summary>
        /// Text.
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// News where comment send.
        /// </summary>
        public NewsDto News { get; set; }
        /// <summary>
        /// NewsId.
        /// </summary>
        public int NewsId { get; set; }
        /// <summary>
        /// LinkedCommentId.  Maybe null, if user leave comment on news.
        /// </summary>
        public CommentsDto LinkedComment { get; set; }
        /// <summary>
        /// LinkedCommentId.
        /// </summary>
        public int? LinkedCommentId { get; set; }
        /// <summary>
        /// Comment State - DELETED - 1 , NOTDELETED - 0
        /// </summary>
        public short CommentState { get; set; }
    }
}
