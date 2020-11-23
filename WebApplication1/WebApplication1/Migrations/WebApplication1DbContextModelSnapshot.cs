﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(WebApplication1DbContext))]
    partial class WebApplication1DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("WebApplication1.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("WebApplication1.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WebApplication1.Models.Admin", b =>
                {
                    b.HasBaseType("WebApplication1.Models.User");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("WebApplication1.Models.Customer", b =>
                {
                    b.HasBaseType("WebApplication1.Models.User");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("WebApplication1.Models.Car", b =>
                {
                    b.HasOne("WebApplication1.Models.Customer", "Customer")
                        .WithMany("Cars")
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("WebApplication1.Models.Admin", b =>
                {
                    b.HasOne("WebApplication1.Models.User", null)
                        .WithOne()
                        .HasForeignKey("WebApplication1.Models.Admin", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Models.Customer", b =>
                {
                    b.HasOne("WebApplication1.Models.User", null)
                        .WithOne()
                        .HasForeignKey("WebApplication1.Models.Customer", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Models.Customer", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
