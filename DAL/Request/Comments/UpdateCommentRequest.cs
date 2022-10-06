using System.ComponentModel.DataAnnotations;

namespace DAL.Request.Comments
{
    /// <summary>
    /// Update request for Comment.
    /// </summary>
    public class UpdateCommentRequest 
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
    }
}
