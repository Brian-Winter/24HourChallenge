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
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        //POST | api/user
        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody] User userToCreate)
        {
            User createdUser = _context.Authors.Add(userToCreate);
            await _context.SaveChangesAsync();
            return Ok(createdUser);
        }
        //GET all users| api/user
        [HttpGet]
        public async Task<IHttpActionResult> GetAllUsers(int id)
        {
            List<User> authors = await _context.Authors.ToListAsync();
            return Ok(authors);
        }

        //GET single user| api/user/:id
        [HttpGet]
        [Route("{id}")]
        public async Task<IHttpActionResult> GetUserById(int id)
        {
            User requestedUser = await _context.Authors.FindAsync(id);

            if (requestedUser == null)
            {
                return NotFound();
            }
            return Ok(requestedUser);
        }

        //PUT | api/user/id
        [HttpPut]
        [Route("{id}")]
        public async Task<IHttpActionResult> UpdateUser([FromUri] int id, [FromBody] User updateUser)
        {
            User requestedUser = await _context.Authors.FindAsync(id);

            if (requestedUser == null)
            {
                return NotFound();
            }
            if (updateUser.Name != null)
            {
                requestedUser.Name = updateUser.Name;
            }

            try
            {
                await _context.SaveChangesAsync();
                return Ok(requestedUser);
            }
            catch (Exception e)
            {
                return (BadRequest(e.Message));
            }
        }

        //DELETE | api/user/id
    }
}
