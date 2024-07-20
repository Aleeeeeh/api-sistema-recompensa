using System.ComponentModel.DataAnnotations;

namespace api_sistema_recompensas.Models.Dtos;

public class UpdateUserDto
{
    [Required(ErrorMessage = "Obrigatório informar o nome do usuário")]
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "Obrigatório informar o tipo de usuário")]
    public string? Email { get; set; }
    public string? CellPhone { get; set; }
    [Required(ErrorMessage = "Obrigatório informar a senha")]
    public string Password { get; set; } = null!;
}
