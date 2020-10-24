using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NerdyNetwork.Data;
using NerdyNetwork.Models;
using Microsoft.AspNet.Identity;

namespace NerdyNetwork.WepAPI.Controllers
{
    [Authorize]
    public class CommentController : ApiController
    {
        //CREATE Comment
        private CommentService CreateCommentService()
        {
            var postId = Comment.PostId;
            var commentService = new CommentService(postId);
            return commentService;
        }
        public IHttpActionResult Post(CommentCreate comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateCommentService();
            if (!service.CreateComment(comment))
            {
                return InternalServerError();
            }
            return Ok();

        }
        //GET Comments
        public IHttpActionResult Get()
        {
            CommentService commentService = CreateCommentService();
            var comments = commentService.GetAllComments();
            return Ok(comments);

        }

        
    }
}
