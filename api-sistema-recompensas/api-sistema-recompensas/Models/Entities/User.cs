using api_sistema_recompensas.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace api_sistema_recompensas.Models.Entities;

public class User
{
    public long Id { get; set; }
    [Required(ErrorMessage = "Obrigatório informar o nome do usuário")]
    public string Name { get; set; } = null!;
    public DateTime DateRegister { get; set; }
    public DateTime UpdateDate { get; set; } = DateTime.UtcNow.ToLocalTime();
    [Required(ErrorMessage = "Obrigatório informar o tipo de usuário")]
    public UserType UserType { get; set; }
    public string? Email { get; set; }
    public string? CellPhone { get; set; }
    [Required(ErrorMessage = "Obrigatório informar a senha")]
    public string Password { get; set; } = null!;
}
