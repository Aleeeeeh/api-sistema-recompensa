using System.ComponentModel.DataAnnotations;

namespace api_sistema_recompensas.Models.Dtos;

public class UpdateTaskDto
{
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "Obrigatório informar a descrição da tarefa")]
    public string Description { get; set; } = null!;
    [Required(ErrorMessage = "Obrigatório informar a quantidade em tokens")]
    public int QuantityToken { get; set; }
}
