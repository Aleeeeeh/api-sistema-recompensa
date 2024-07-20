using api_sistema_recompensas.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace api_sistema_recompensas.Models.Entities;
public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<Account> Account { get; set; }
    public DbSet<Request> Request { get; set; }
    public DbSet<Reward> Reward { get; set; }
    public DbSet<SystemTask> SystemTask { get; set; }
    public DbSet<Token> Token { get; set; }
    public DbSet<User> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountContext());
        modelBuilder.ApplyConfiguration(new RequestContext());
        modelBuilder.ApplyConfiguration(new RewardContext());
        modelBuilder.ApplyConfiguration(new SystemTaskContext());
        modelBuilder.ApplyConfiguration(new TokenContext());
        modelBuilder.ApplyConfiguration(new UserContext());
        base.OnModelCreating(modelBuilder);
    }
}
