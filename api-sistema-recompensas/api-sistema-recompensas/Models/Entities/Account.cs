namespace api_sistema_recompensas.Models.Entities;

public class Account
{
    public long Id { get; set; }
    public decimal Balance { get; set; }
    public DateTime DateLastUpdate { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}
