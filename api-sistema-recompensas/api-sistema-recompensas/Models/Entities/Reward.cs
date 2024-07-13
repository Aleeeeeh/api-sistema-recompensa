namespace api_sistema_recompensas.Models.Entities;

public class Reward
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime DateRegister { get; set; }
    public int QuantityToken { get; set; }
}
