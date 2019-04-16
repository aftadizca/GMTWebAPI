﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Models;

namespace WebApi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApi.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("WebApi.Models.Material", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Suplier")
                        .IsRequired();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.Property<string>("Unit")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("WebApi.Models.StatusQC", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("StatusQCs");
                });

            modelBuilder.Entity("WebApi.Models.Stok", b =>
                {
                    b.Property<string>("TraceID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ComingDate");

                    b.Property<DateTime>("ExpiredDate");

                    b.Property<int>("LocationID");

                    b.Property<string>("Lot");

                    b.Property<string>("MaterialID");

                    b.Property<int>("QTY");

                    b.Property<int>("StatusQCID");

                    b.HasKey("TraceID");

                    b.HasIndex("LocationID")
                        .IsUnique();

                    b.HasIndex("MaterialID");

                    b.HasIndex("StatusQCID");

                    b.ToTable("Stoks");
                });

            modelBuilder.Entity("WebApi.Models.Stok", b =>
                {
                    b.HasOne("WebApi.Models.Location", "Location")
                        .WithOne("Stok")
                        .HasForeignKey("WebApi.Models.Stok", "LocationID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApi.Models.Material", "Material")
                        .WithMany("Stoks")
                        .HasForeignKey("MaterialID");

                    b.HasOne("WebApi.Models.StatusQC", "StatusQC")
                        .WithMany("Stoks")
                        .HasForeignKey("StatusQCID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
