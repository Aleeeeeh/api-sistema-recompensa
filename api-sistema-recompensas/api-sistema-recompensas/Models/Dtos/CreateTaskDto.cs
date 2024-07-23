using api_sistema_recompensas.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace api_sistema_recompensas.Models.Dtos;

public class CreateTaskDto
{
    public string Name { get; set; } = null!;
    [Required(ErrorMessage = "Obrigatório informar a descrição da tarefa")]
    public string Description { get; set; } = null!;
    [Required(ErrorMessage = "Obrigatório informar a quantidade em tokens")]
    public int QuantityToken { get; set; }
    public TaskSituation Situation { get; set; } = (TaskSituation)1;
}
