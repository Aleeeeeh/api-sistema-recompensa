namespace api_sistema_recompensas.Models.Entities;

public class SystemTask
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int QuantityToken { get; set; }
}
