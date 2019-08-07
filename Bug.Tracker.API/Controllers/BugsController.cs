using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bug.Tracker.DocumentStore;
using Bug.Tracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bug.Tracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugsController : ControllerBase
    {
        private readonly BugTrackerStore _bugTrackerStore;

        public BugsController(BugTrackerStore bugTrackerStore)
        {
            _bugTrackerStore = bugTrackerStore;
        }

        // GET api/bugs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BugItem>>> GetAsync()
        {
            return Ok(await _bugTrackerStore.GetBugs());
        }

        // GET api/bugs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetAsync(Guid id)
        {
            return Ok(await _bugTrackerStore.FindBug(id));
        }

        [HttpPost("title/{title}/description/{description}")]
        public async Task<ActionResult> CreateBug(string title, string description)
        {
            try
            {
                return Ok(await _bugTrackerStore.AddBug(title, description));
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpPut("id/{id}/status/{status}")]
        public async Task<ActionResult> UpdateBug(Guid id, string status)
        {
            try
            {
                return Ok(await _bugTrackerStore.UpdateBug(id, status));
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpPut("id/{id}/status/{status}/user-id/{userId}")]
        public async Task<ActionResult> UpdateBugWithUserId(Guid id, string status, string userId)
        {
            try
            {
                return Ok(await _bugTrackerStore.UpdateBug(id, status, userId));
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
