using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdyNetwork.Data
{
    public class Reply
    {
        [Key]
        public int CommentReplyId{ get; set; }

        [ForeignKey(nameof(Comments))]
        public int CommentId { get; set; }
        public Comments Comment { get; set; }
        // public int MyProperty { get; set; } replyComment
    }
}
