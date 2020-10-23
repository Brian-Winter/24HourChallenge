using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdyNetwork.Data
{
    public class Likes
    {
        [ForeignKey(nameof(Post)]
        public int PostId { get; set; }
        public Post LikedPost { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User user { get; set; }

    }
}