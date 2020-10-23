using NerdyNetwork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdyNetwork.Models
{
    class CommentService
    {
        private readonly int _PostId;
        public CommentService(int PostId)
        {
            _PostId = PostId;
        }
        //POST a post
        public bool CreateComment(CommentCreate model)
        {
            var newComment =
                new Comments()
                {
                    PostId = _PostId,
                    CommentText = model.CommentText,
                };
            using (var content = new ApplicationDbContext())
            {
                content.Comments.Add(newComment);
                return content.SaveChanges() == 1;
            }
        }
       //POST on Comment
       //Get comment by Id -> create comment

        //GET Post Comments (read all)
        public IEnumerable<CommentListItem> GetAllComments()
        {
            using (var content = new ApplicationDbContext())
            {
                var query =
                    content
                        .Comments
                        .Where(e => e.PostId == _PostId)
                        .Select(
                            e =>
                            new CommentListItem
                            {
                                CommentId = e.CommentId,
                                CommentText = e.CommentText,
                                UserId = e.UserId
                            }
                        );
                return query.ToArray();
            }
        }
    }
}
