using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Model;
using TodoList.Model.Enums;
using TodoListBlazor.Api.Repositories;

namespace TodoListBlazor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var task = await _taskRepository.GetTaskList();
            var taskDtos = task.Select(c => new TaskDto()
            {
                Status = c.Status,
                Name = c.Name,
                AssigneeId = c.AssigneeId,
                CreateDate = c.CreateDate,
                Priority = c.Priority,
                Id = c.Id,
                AssigneeName = c.Assignee != null ? c.Assignee.FirstName + " " + c.Assignee.LastName :"Chưa có"
            });
            return Ok(taskDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var task = await _taskRepository.Create(new Enities.Task()
            {
                Name = request.Name,
                Priority = request.Priority,
                Status = Status.Open,
                CreateDate = DateTime.Now,
                Id = Guid.NewGuid()//tự new Guid
        });
            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
        }

        //apis.tasks/xx
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var task = await _taskRepository.GetById(id);
            if (task == null)
            {
                return NotFound($"{id} is not found");
            }
            return Ok(new TaskDto()
            {
                Name = task.Name,
                Status = task.Status,
                Id = task.Id,
                AssigneeId = task.AssigneeId,
                Priority = task.Priority,
                CreateDate = task.CreateDate
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, TaskUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tasks = await _taskRepository.GetById(id);
            if (tasks == null)
            {
                return NotFound($"{id} is not found");
            }
            tasks.Name = request.Name;
            tasks.Priority = request.Priority;
            var result = await _taskRepository.Update(tasks);
            return Ok(new TaskDto()
            {
                Name = result.Name,
                Status = result.Status,
                Id = result.Id,
                AssigneeId = result.AssigneeId,
                Priority = result.Priority,
                CreateDate = result.CreateDate
            });
        }
    }
}
