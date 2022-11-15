using NewsPortal.DAL.Response.Comments;
using System.Collections.Generic;


namespace NewsPortal.DAL.Response.News
{
    public class NewsResponse
    {
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
        public int AuthorId { get; set; }
        /// <summary>
        /// AuthorName.
        /// </summary>
        public string AuthorName { get; set; }
        /// <summary>
        /// NewsComments.
        /// </summary>
        public ICollection<CommentsResponse> NewsComments { get; set; }
    }
}
