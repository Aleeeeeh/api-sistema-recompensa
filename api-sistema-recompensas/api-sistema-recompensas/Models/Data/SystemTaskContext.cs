﻿using api_sistema_recompensas.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_sistema_recompensas.Models.Data;

public class SystemTaskContext : IEntityTypeConfiguration<SystemTask>
{
    public void Configure(EntityTypeBuilder<SystemTask> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Description)
            .IsRequired();

        builder.Property(x => x.QuantityToken)
            .IsRequired();

        builder.Property(x => x.Situation)
            .HasConversion<string>()
            .IsRequired();
    }
}
