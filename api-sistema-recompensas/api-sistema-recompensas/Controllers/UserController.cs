using api_sistema_recompensas.Exceptions;
using api_sistema_recompensas.Models.Dtos;
using api_sistema_recompensas.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_sistema_recompensas.Controllers;

[ApiController]
[Route("user")]
public class UserController(UserService userService) : Controller
{
    private readonly UserService _userService = userService;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateUser(UserPostDto userDto)
    {
        try
        {
            var usuario = await _userService.InsertUser(userDto);

            return CreatedAtAction(nameof(CreateUser), new { id = usuario.Id }, usuario);
        }
        catch (UserException ex)
        {
            Console.WriteLine($"{ex.Message} - {ex.InnerException}");
            throw;
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromQuery] long id, UserUpdateDto userDto)
    {
        try
        {
            await _userService.UpdateUser(userDto, id);

            return NoContent();
        }
        catch (UserException ex)
        {
            Console.WriteLine($"{ex.Message} - {ex.InnerException}");
            throw;
        }
    }
}
