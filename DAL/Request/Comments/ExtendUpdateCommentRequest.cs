using System.ComponentModel.DataAnnotations;

namespace NewsPortal.DAL.Request.Comments
{
    /// <summary>
    /// Update request for Comment.
    /// </summary>
    public class ExtendUpdateCommentRequest
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// Text.
        /// </summary>
        [Required]
        public string Text { get; set; }
        /// <summary>
        /// AuthorId.
        /// </summary>
        [Required]
        public int AuthorId { get; set; }
        /// <summary>
        /// NewsId.
        /// </summary>
        [Required]
        public int NewsId { get; set; }
        /// <summary>
        /// LinkedCommentId.
        /// </summary>
        public int? LinkedCommentId { get; set; }
    }
}
