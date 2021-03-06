﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdyNetwork.Data
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User Author { get; set; }
        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }
        public Post CommentPost { get; set; }
}
