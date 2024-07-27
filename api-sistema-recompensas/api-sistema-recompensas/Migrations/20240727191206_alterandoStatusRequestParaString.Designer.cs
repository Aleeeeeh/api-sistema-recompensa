﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api_sistema_recompensas.Models.Entities;

#nullable disable

namespace api_sistema_recompensas.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240727191206_alterandoStatusRequestParaString")]
    partial class alterandoStatusRequestParaString
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("api_sistema_recompensas.Models.Entities.Account", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateLastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Account");
                });

            modelBuilder.Entity("api_sistema_recompensas.Models.Entities.Request", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Bonus")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StatusRequest")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TaskId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UserIdApprover")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserIdRequester")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.HasIndex("UserIdApprover");

                    b.HasIndex("UserIdRequester");

                    b.ToTable("Request");
                });

            modelBuilder.Entity("api_sistema_recompensas.Models.Entities.Reward", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateRegister")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("QuantityToken")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Reward");
                });

            modelBuilder.Entity("api_sistema_recompensas.Models.Entities.SystemTask", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("QuantityToken")
                        .HasColumnType("int");

                    b.Property<string>("Situation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SystemTask");
                });

            modelBuilder.Entity("api_sistema_recompensas.Models.Entities.Token", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("ValueInReal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Token");
                });

            modelBuilder.Entity("api_sistema_recompensas.Models.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CellPhone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("DateRegister")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("api_sistema_recompensas.Models.Entities.Account", b =>
                {
                    b.HasOne("api_sistema_recompensas.Models.Entities.User", "User")
                        .WithOne()
                        .HasForeignKey("api_sistema_recompensas.Models.Entities.Account", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("api_sistema_recompensas.Models.Entities.Request", b =>
                {
                    b.HasOne("api_sistema_recompensas.Models.Entities.SystemTask", "Task")
                        .WithMany("Requests")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("api_sistema_recompensas.Models.Entities.User", "UserApprover")
                        .WithMany("RequestsAsApprover")
                        .HasForeignKey("UserIdApprover")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("api_sistema_recompensas.Models.Entities.User", "UserRequester")
                        .WithMany("RequestsAsRequester")
                        .HasForeignKey("UserIdRequester")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Task");

                    b.Navigation("UserApprover");

                    b.Navigation("UserRequester");
                });

            modelBuilder.Entity("api_sistema_recompensas.Models.Entities.SystemTask", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("api_sistema_recompensas.Models.Entities.User", b =>
                {
                    b.Navigation("RequestsAsApprover");

                    b.Navigation("RequestsAsRequester");
                });
#pragma warning restore 612, 618
        }
    }
}
