using api_sistema_recompensas.Models.Enums;

namespace api_sistema_recompensas.Models.Entities;

public class Request
{
    public long Id { get; set; }
    public int TaskId { get; set; }
    public Task Task { get; set; } = null!;
    public StatusRequest StatusRequest { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ApprovalDate { get; set; }
    public int UserIdRequester { get; set; }
    public int UserIdApprover { get; set; }
    public User User { get; set; } = null!;
    public int Bonus { get; set; }
}
