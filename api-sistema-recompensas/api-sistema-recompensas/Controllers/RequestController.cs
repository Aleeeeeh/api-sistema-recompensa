using api_sistema_recompensas.Exceptions;
using api_sistema_recompensas.Models.Dtos;
using api_sistema_recompensas.Models.Entities;
using api_sistema_recompensas.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_sistema_recompensas.Controllers;

[ApiController]
[Route("request")]
public class RequestController(RequestService service) : Controller
{
    private readonly RequestService _service = service;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> OpenRequest(CreateRequestDto dto)
    {
        try
        {
            Request request = await _service.OpenRequest(dto);

            return CreatedAtAction(nameof(OpenRequest), new { id = request.Id }, request);
        }
        catch (TaskException ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> RespondToRequest(RequestAnalysisDto dto)
    {
        try
        {
            await _service.RespondToRequest(dto);

            return NoContent();
        }
        catch (TaskException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, ex.Message);
        }
    }

    [HttpGet("por-situacao")]
    public async Task<IActionResult> GetRequestsBySituation([FromQuery] int situacao)
    {
        try
        {
            IEnumerable<Request> requests = await _service.GetRequestsBySituation(situacao);

            return Ok(requests);
        }
        catch (TaskException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, ex.Message);
        }
    }
}
