using api_sistema_recompensas.Models.Enums;

namespace api_sistema_recompensas.Models.Entities;

public class User
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime DateRegister { get; set; }
    public UserType UserType { get; set; }
    public string? Email { get; set; }
    public string? CellPhone { get; set; }
    public string Password { get; set; } = null!;
}
