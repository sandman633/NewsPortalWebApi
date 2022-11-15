using System.ComponentModel.DataAnnotations;

namespace NewsPortal.DAL.Request.Comments
{
    /// <summary>
    /// Request new comment model.
    /// </summary>
    public class NewCommentRequest
    {
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
    }
}
