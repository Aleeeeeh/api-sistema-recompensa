using api_sistema_recompensas.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace api_sistema_recompensas.Models.Entities;

public class Request
{
    public long Id { get; set; }
    [Required(ErrorMessage = "Obrigatório informar a tarefa")]
    [JsonIgnore]
    public long TaskId { get; set; }
    public SystemTask Task { get; set; } = null!;
    [Required(ErrorMessage = "Obrigatório informar o status da solicitação")]
    public StatusRequest StatusRequest { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime UpdateDate { get; set; }
    [JsonIgnore]
    public long? UserIdRequester { get; set; }
    public User UserRequester { get; set; } = null!;
    [JsonIgnore]
    public long? UserIdApprover { get; set; }
    public User UserApprover { get; set; } = null!;
    public int Bonus { get; set; }
}
