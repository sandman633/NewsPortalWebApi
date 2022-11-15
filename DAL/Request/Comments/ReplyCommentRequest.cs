namespace NewsPortal.DAL.Request.Comments
{
    /// <summary>
    /// Request new comment reply model.
    /// </summary>
    public class ReplyCommentRequest : NewCommentRequest
    {
        /// <summary>
        /// LinkedCommentId.
        /// </summary>
        public int? LinkedCommentId { get; set; }
    }
}
