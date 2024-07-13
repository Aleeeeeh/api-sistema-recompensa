namespace api_sistema_recompensas.Models.Dtos;

public class RequestAnalysisDto
{
    public int UserIdApprover { get; set; }
    public int Status { get; set; }
    public long IdRequest { get; set; }
    public int Bonus { get; set; }
}
