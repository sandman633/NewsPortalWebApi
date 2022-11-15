using System.ComponentModel.DataAnnotations;

namespace NewsPortal.DAL.Request.News
{
    /// <summary>
    /// Request new News model.
    /// </summary>
    public class NewNewsRequest
    {
        /// <summary>
        /// Header.
        /// </summary>
        [Required]
        public string Header { get; set; }
        /// <summary>
        /// Body.
        /// </summary>
        [Required]
        public string Body { get; set; }
        /// <summary>
        /// AuthorId.
        /// </summary>
        [Required]
        public int AuthorId { get; set; }
    }
}
