using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using backend.Data; 

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;
        private readonly TaskDbContext _context;  

        public TaskController(ILogger<TaskController> logger, TaskDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Task>> GetAllTasks()
        {
            var tasks = _context.Tasks.ToList();  
            return Ok(tasks);
        }
        [HttpPost]
        public ActionResult<Task> AddTask(Task task){
            _logger.LogInformation($"Received task: {task.Title}, {task.Description}, {task.Status}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return Ok(task);
        }

        [HttpPut]
        public ActionResult<Task> UpdateTask(Task task){
            _logger.LogInformation($"Received task: {task.Title}, {task.Description}, {task.Status}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Tasks.Update(task);
            _context.SaveChanges();
            return Ok(task);
        }

        
        [HttpDelete("{id}")]
        public ActionResult<Task> DeleteTask(int id) {
            var task = _context.Tasks.Find(id);
            if(task == null) {
                return NotFound();
            } else {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
                return Ok(task);
            }
            }
        }

    }

