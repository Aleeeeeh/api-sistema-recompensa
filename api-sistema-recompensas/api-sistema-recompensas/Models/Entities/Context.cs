using api_sistema_recompensas.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace api_sistema_recompensas.Models.Entities;
public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<Reward> Rewards { get; set; }
    public DbSet<SystemTask> SystemTasks { get; set; }
    public DbSet<Token> Tokens { get; set; }
    public DbSet<User> Users { get; set; }

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
