using System.ComponentModel.DataAnnotations;

namespace DAL.Request.News
{
    /// <summary>
    /// Update request for News.
    /// </summary>
    public class UpdateNewsRequest
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// Header.
        /// </summary>
        public string Header { get; set; }
        /// <summary>
        /// Body.
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// AuthorId.
        /// </summary>
        public int? AuthorId { get; set; }
    }
}
