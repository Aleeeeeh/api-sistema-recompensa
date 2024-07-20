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
            .WithOne()
            .HasForeignKey<Request>(x => x.TaskId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.StatusRequest)
            .IsRequired();

        builder.Property(x => x.CreationDate)
            .IsRequired();

        builder.Property(x => x.ApprovalDate)
            .IsRequired();

        builder.HasOne(x => x.UserApprover)
            .WithOne()
            .HasForeignKey<Request>(x => x.UserIdApprover)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.UserRequester)
            .WithOne()
            .HasForeignKey<Request>(x => x.UserIdRequester)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Bonus)
            .IsRequired();
    }
}
