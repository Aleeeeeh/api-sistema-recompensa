using System.ComponentModel.DataAnnotations;

namespace api_sistema_recompensas.Models.Entities;

public class Account
{
    public long Id { get; set; }
    [Required(ErrorMessage = "Obrigatório informar a quantidade em tokens")]
    public decimal Balance { get; set; }
    public DateTime DateLastUpdate { get; set; }
    [Required(ErrorMessage = "Obrigatório informar o usuário")]
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}
