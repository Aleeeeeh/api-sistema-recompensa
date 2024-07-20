using System.ComponentModel.DataAnnotations;

namespace api_sistema_recompensas.Models.Dtos;

public class TokenDto
{
    [Required(ErrorMessage = "Obrigatório informar o valor em real")]
    public decimal ValueInReal { get; set; }
}
