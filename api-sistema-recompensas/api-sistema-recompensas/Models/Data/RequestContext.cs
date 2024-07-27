using api_sistema_recompensas.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_sistema_recompensas.Models.Data;

public class RequestContext : IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Task)
            .WithMany(t => t.Requests)
            .HasForeignKey(x => x.TaskId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.StatusRequest)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(x => x.CreationDate)
            .IsRequired();

        builder.Property(x => x.UpdateDate);

        builder.HasOne(x => x.UserApprover)
            .WithMany(t => t.RequestsAsApprover)
            .HasForeignKey(x => x.UserIdApprover)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.UserRequester)
            .WithMany(t => t.RequestsAsRequester)
            .HasForeignKey(x => x.UserIdRequester)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Bonus);
    }
}
