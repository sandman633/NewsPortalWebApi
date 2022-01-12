﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Response.Comments
{
    public class CommentsResponse 
    {
        public string UserName { get; set; }

        public int CommentId { get; set; }

        public string Text { get; set; }

        public int NewsId { get; set; }

        public int? LinkedCommentId { get; set; }
    }
}