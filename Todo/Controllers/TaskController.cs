using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Todo.Models;
using Todo.Services;

namespace Todo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController: ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Tasks>> GetTask(int id)
    {
        var task = await _taskService.GetTask(id);
        if(task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }

    [HttpGet]
    public async Task<ActionResult<List<Tasks>>> GetTasks()
    {
        return await _taskService.GetAllTasks();
    }

    [HttpPost]
    public async Task<ActionResult<Tasks>> CreateTask(Tasks task) // check if Id already exists and if it does do not create
    {
        await _taskService.CreateTask(task);
        return CreatedAtAction(nameof(GetTask), new {id = task.Id}, task);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Tasks>> UpdateTask(int id, Tasks task)
    {
        if(id != task.Id)
        {
            return BadRequest();
        }
        var updatedTask = await _taskService.UpdateTask(id, task);
        if(updatedTask == null)
        {
            return NotFound();
        }
        return Ok(task);
    }
}