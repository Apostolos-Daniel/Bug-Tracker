using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bug.Tracker.DocumentStore;
using Bug.Tracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bug.Tracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserStore _bugTrackerStore;

        public UsersController(UserStore bugTrackerStore)
        {
            _bugTrackerStore = bugTrackerStore;
        }

        // GET api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAsync()
        {
            var users = await _bugTrackerStore.GetAll<User>();
            return Ok(users);
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetAsync(Guid id)
        {
            return Ok(await _bugTrackerStore.Find(id));
        }

        [HttpPost("name/{name}")]
        public async Task<ActionResult<User>> CreateUser(string name)
        {
            try
            {
                return Ok(await _bugTrackerStore.AddItem(new User { Name = name }));
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpPut("id/{id}/name/{name}")]
        public async Task<ActionResult> UpdateUser(Guid id, string name)
        {
            try
            {
                await _bugTrackerStore.UpdateItem(new User { Id = id, Name = name });
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
