using NerdyNetwork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdyNetwork.Models
{
    class LikeCreate
    {
        private readonly int _PostId;
        private readonly int _UserId;

        public LikeCreate(int PostId, int userId)
        {
            _PostId = PostId;
            _UserId = userId;
        }
        public bool LikePost()
        {
            var newLike =
                   new Likes()
                   {
                       PostId = _PostId,
                       UserId = _UserId,

                   };
            using (var content = new ApplicationDbContext())
            {
                content.Likes.Add(newLike);
                return content.SaveChanges() == 1;
            }
        }
    }
}
