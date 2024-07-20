using api_sistema_recompensas.Exceptions;
using api_sistema_recompensas.Models.Dtos;
using api_sistema_recompensas.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_sistema_recompensas.Controllers;

[ApiController]
[Route("token")]
public class TokenController(TokenService service) : Controller
{
    private readonly TokenService _service = service;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateToken(TokenDto tokenDto)
    {
        try
        {
            var token = await _service.CreateToken(tokenDto);

            return CreatedAtAction(nameof(CreateToken), new { id = token.Id }, token);
        }
        catch (TokenException ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> SetToken(TokenDto tokenDto)
    {
        try
        {
            await _service.SetToken(tokenDto);

            return NoContent();
        }
        catch (TokenException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, ex.Message);
        }
    }
}
