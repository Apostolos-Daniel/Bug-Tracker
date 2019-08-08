using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bug.Tracker.DocumentStore;
using Bug.Tracker.Models;
using Bug.Tracker.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Bug.Tracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugsController : ControllerBase
    {
        private readonly BugStore _bugTrackerStore;

        public BugsController(BugStore bugTrackerStore)
        {
            _bugTrackerStore = bugTrackerStore;
        }

        // GET api/bugs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BugItem>>> GetAsync()
        {
            var bugs = await _bugTrackerStore.GetAll<BugItem>();
            return Ok(bugs);
        }

        // GET api/bugs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetAsync(Guid id)
        {
            return Ok(await _bugTrackerStore.Find(id));
        }

        [HttpPost("title/{title}/description/{description}")]
        public async Task<ActionResult> CreateBug(string title, string description)
        {
            try
            {
                return Ok(await _bugTrackerStore.AddItem(new BugItem { Title = title, Description = description }));
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
                await _bugTrackerStore.UpdateItem(new BugItem { Id = id, Status = Enum.Parse<BugStatus>(status) });
                return Ok();
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
                await _bugTrackerStore.UpdateItem(new BugItem { Id = id, Status = Enum.Parse<BugStatus>(status), AssignedTo = userId });
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
