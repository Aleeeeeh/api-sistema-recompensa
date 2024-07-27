using api_sistema_recompensas.Models.Enums;

namespace api_sistema_recompensas.Models.Dtos;

public class RequestAnalysisDto
{
    public int UserIdApprover { get; set; }
    public StatusRequest StatusRequest { get; set; }
    public long IdRequest { get; set; }
    public int Bonus { get; set; }
}
