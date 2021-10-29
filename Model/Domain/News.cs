﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Domain
{
    public class News : BaseEntity
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public ICollection<Comments> Сomments { get; set; }

    }
}
