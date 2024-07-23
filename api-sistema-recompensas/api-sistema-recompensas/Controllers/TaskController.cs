using api_sistema_recompensas.Exceptions;
using api_sistema_recompensas.Models.Dtos;
using api_sistema_recompensas.Models.Entities;
using api_sistema_recompensas.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_sistema_recompensas.Controllers;

[ApiController]
[Route("task")]
public class TaskController(TaskService service) : Controller
{
    private readonly TaskService _service = service;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateTask(CreateTaskDto dto)
    {
        try
        {
            SystemTask task = await _service.CreateTask(dto);

            return CreatedAtAction(nameof(CreateTask), new { id = task.Id }, task);
        }
        catch (TaskException ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut("/altera")]
    public async Task<IActionResult> ChangeTask([FromQuery] long id, [FromBody] UpdateTaskDto dto)
    {
        try
        {
            await _service.ChangeTask(id, dto);

            return NoContent();
        }
        catch (TaskException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetTasks()
    {
        var task = await _service.GetTasks();

        if (task is null)
            return NoContent();

        return Ok(task);
    }

    [HttpPut("/inativa")]
    public async Task<IActionResult> DisableTask([FromQuery] long id)
    {
        try
        {
            await _service.DisableTask(id);

            return NoContent();
        }
        catch (TaskException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, ex.Message);
        }
    }

    [HttpPut("/ativa")]
    public async Task<IActionResult> ActivateTask([FromQuery] long id)
    {
        try
        {
            await _service.ActivateTask(id);

            return NoContent();
        }
        catch (TaskException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, ex.Message);
        }
    }
}
