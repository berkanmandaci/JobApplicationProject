using Microsoft.AspNetCore.Mvc;
using JobApplicationProject.Contracts;
using JobApplicationProject.DTOs;

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
        public async Task<ActionResult<IEnumerable<TaskItemDto>>> GetTaskItems()
        {
            return Ok(await _service.GetAllAsync());
        }

        // GET: api/TaskItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItemDto>> GetTaskItem(long id)
        {
            var taskItem = await _service.GetByIdAsync(id);

            if (taskItem == null)
            {
                return NotFound();
            }

            return taskItem;
        }

        // PUT: api/TaskItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskItem(long id, TaskItemDto taskItem)
        {
            var result = await _service.UpdateAsync(id, taskItem);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // POST: api/TaskItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskItemDto>> PostTaskItem(TaskItemDto taskItem)
        {
            var createdTaskItem = await _service.CreateAsync(taskItem);
            return CreatedAtAction(nameof(GetTaskItem), new { id = createdTaskItem.Id }, createdTaskItem);
        }

        // DELETE: api/TaskItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskItem(long id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
} 