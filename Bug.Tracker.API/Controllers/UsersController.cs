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
        private readonly BugTrackerStore _bugTrackerStore;

        public UsersController(BugTrackerStore bugTrackerStore)
        {
            _bugTrackerStore = bugTrackerStore;
        }

        // GET api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAsync()
        {
            var users = await _bugTrackerStore.GetUsers();
            return Ok(users);
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetAsync(Guid id)
        {
            return Ok(await _bugTrackerStore.FindUser(id));
        }

        [HttpPost("name/{name}")]
        public async Task<ActionResult<User>> CreateUser(string name)
        {
            try
            {
                return Ok(await _bugTrackerStore.AddUser(name));
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
                return Ok(await _bugTrackerStore.UpdateUser(id, name));
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
