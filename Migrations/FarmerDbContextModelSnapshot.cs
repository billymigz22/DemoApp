﻿// <auto-generated />
using System;
using DemoApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DemoApp.Migrations
{
    [DbContext(typeof(FarmerDbContext))]
    partial class FarmerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DemoApp.Models.Farm", b =>
                {
                    b.Property<int>("FarmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FarmId"), 1L, 1);

                    b.Property<string>("FarmAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FarmerId")
                        .HasColumnType("int");

                    b.Property<int>("Hectare")
                        .HasColumnType("int");

                    b.Property<string>("TenurialStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FarmId");

                    b.HasIndex("FarmerId");

                    b.ToTable("Farms");
                });

            modelBuilder.Entity("DemoApp.Models.Farmer", b =>
                {
                    b.Property<int>("FarmerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FarmerId"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FarmerId");

                    b.ToTable("Farmers");
                });

            modelBuilder.Entity("DemoApp.Models.Farm", b =>
                {
                    b.HasOne("DemoApp.Models.Farmer", "Farmer")
                        .WithMany("Farms")
                        .HasForeignKey("FarmerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Farmer");
                });

            modelBuilder.Entity("DemoApp.Models.Farmer", b =>
                {
                    b.Navigation("Farms");
                });
#pragma warning restore 612, 618
        }
    }
}
