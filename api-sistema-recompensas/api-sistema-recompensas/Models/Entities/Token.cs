using System.ComponentModel.DataAnnotations;

namespace api_sistema_recompensas.Models.Entities;

public class Token
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Obrigatório informar o valor em real")]
    public decimal ValueInReal { get; set; }
}
