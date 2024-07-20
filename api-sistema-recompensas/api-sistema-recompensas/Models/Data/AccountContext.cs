using api_sistema_recompensas.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_sistema_recompensas.Models.Data;

public class AccountContext : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Balance)
            .IsRequired();

        builder.Property(x => x.DateLastUpdate)
            .IsRequired();

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.HasOne(x => x.User)
            .WithOne()
            .HasForeignKey<Account>(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
