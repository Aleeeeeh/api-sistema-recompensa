using System.ComponentModel.DataAnnotations;

namespace api_sistema_recompensas.Models.Entities;

public class Reward
{
    public long Id { get; set; }
    [Required(ErrorMessage = "Obrigatório informar o nome da recompensa")]
    public string Name { get; set; } = null!;
    public DateTime DateRegister { get; set; }
    [Required(ErrorMessage = "Obrigatório informar a quantidade em tokens")]
    public int QuantityToken { get; set; }
}
