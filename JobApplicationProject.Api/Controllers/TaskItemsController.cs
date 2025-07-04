using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JobApplicationProject.Models;
using JobApplicationProject.Contracts;

namespace JobApplicationProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController : ControllerBase
    {
        private readonly ITaskItemService _service;

        public TaskItemsController(ITaskItemService service)
        {
            _service = service;
        }

        // GET: api/TaskItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTaskItems()
        {
            return Ok(await _service.GetAllTaskItemsAsync());
        }

        // GET: api/TaskItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTaskItem(long id)
        {
            var taskItem = await _service.GetTaskItemByIdAsync(id);

            if (taskItem == null)
            {
                return NotFound();
            }

            return taskItem;
        }

        // PUT: api/TaskItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskItem(long id, TaskItem taskItem)
        {
            var result = await _service.UpdateTaskItemAsync(id, taskItem);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // POST: api/TaskItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskItem>> PostTaskItem(TaskItem taskItem)
        {
            var createdTaskItem = await _service.CreateTaskItemAsync(taskItem);
            return CreatedAtAction(nameof(GetTaskItem), new { id = createdTaskItem.Id }, createdTaskItem);
        }

        // DELETE: api/TaskItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskItem(long id)
        {
            var result = await _service.DeleteTaskItemAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
} 