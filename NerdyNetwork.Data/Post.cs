using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdyNetwork.Data
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "Are you writing a novel? Please write")]
        public string Text { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User Author { get; set; }
    }
}
