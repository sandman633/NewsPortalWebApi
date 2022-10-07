using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Domain
{
    public class Comments : BaseEntity
    {
        /// <summary>
        /// User navigation property
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// Author of comment
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// nesting level
        /// </summary>
        public int Root { get; set; }
        /// <summary>
        /// Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Date of news creation
        /// </summary>
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// Date of news update
        /// </summary>
        public DateTime UpdatedTime { get; set; }
        /// <summary>
        /// News navigation property
        /// </summary>
        public News News { get; set; }
        /// <summary>
        /// News Id
        /// </summary>
        public int NewsId { get; set; }
        /// <summary>
        /// Linked Comment
        /// </summary>
        public Comments LinkedComment { get; set; }
        /// <summary>
        /// Linked Comment Id
        /// </summary>
        public int? LinkedCommentId { get; set; }

        /// <summary>
        /// Comment State - DELETED, NOTDELETED
        /// </summary>
        public CommentState CommentState { get; set; }
    }

    public enum CommentState : short
    {
        NOTDELETED = 0,
        DELETED = 1
    }
}
