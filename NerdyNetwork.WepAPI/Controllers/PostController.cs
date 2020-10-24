using NerdyNetwork.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace NerdyNetwork.WepAPI.Controllers
{
    [RoutePrefix("api/post")]
    public class PostController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody] Post postToCreate)
        {
            Post createdPost = _context.Posts.Add(postToCreate);
            await _context.SaveChangesAsync();
            return Ok(createdPost);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllPosts(int id)
        {
            List<Post> posts = await _context.Posts.ToListAsync();
            return Ok(posts);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetPostById(int id)
        {
            Post requestedPost = await _context.Posts.FindAsync(id);
            if (requestedPost == null)
            {
                return NotFound();
            }
            return Ok(requestedPost);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IHttpActionResult> UpdatePost([FromUri] int id, [FromBody] Post updatePost)
        {
            Post requestedPost = await _context.Posts.FindAsync(id);
            if (requestedPost == null)
            {
                return NotFound();
            }
            if (updatePost.Text != null)
            {
                requestedPost.Text = updatePost.Text;
            }
            try
            {
                await _context.SaveChangesAsync();
                return Ok(requestedPost);
            }
            catch (Exception e)
            {
                return (BadRequest(e.Message));
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IHttpActionResult> DeletePost([FromUri] int id)
        {
            Post requestedPost = await _context.Posts.FindAsync(id);
            if (requestedPost == null)
            {
                return NotFound();
            }
            try
            {
                _context.Posts.Remove(requestedPost);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
