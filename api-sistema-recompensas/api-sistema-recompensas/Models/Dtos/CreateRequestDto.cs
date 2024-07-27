using System.ComponentModel.DataAnnotations;

namespace api_sistema_recompensas.Models.Dtos;

public class CreateRequestDto
{
    [Required(ErrorMessage = "Obrigatório informar a tarefa")]
    public long TaskId { get; set; }
    [Required(ErrorMessage = "Obrigatório informar o status da solicitação")]
    public long UserIdRequester { get; set; }
}
