using api_sistema_recompensas.Exceptions;
using api_sistema_recompensas.Models.Entities;
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
    public async Task<ActionResult<User>> CreateUser(User user)
    {
        try
        {
            var usuario = await _userService.InsertUser(user);

            return CreatedAtAction(nameof(CreateUser), new { id = usuario.Id }, usuario);
        }
        catch (UserException ex)
        {
            Console.WriteLine($"{ex.Message} - {ex.InnerException}");
            throw;
        }
    }
}
