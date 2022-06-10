﻿// <auto-generated />
using System;
using DemoApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DemoApp.Migrations
{
    [DbContext(typeof(FarmerDbContext))]
    [Migration("20220610015741_Farmcropping")]
    partial class Farmcropping
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CroppingFarm", b =>
                {
                    b.Property<int>("CroppingsCroppingId")
                        .HasColumnType("int");

                    b.Property<int>("FarmsFarmId")
                        .HasColumnType("int");

                    b.HasKey("CroppingsCroppingId", "FarmsFarmId");

                    b.HasIndex("FarmsFarmId");

                    b.ToTable("CroppingFarm");
                });

            modelBuilder.Entity("DemoApp.Models.Cropping", b =>
                {
                    b.Property<int>("CroppingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CroppingId"), 1L, 1);

                    b.Property<string>("Crop")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CroppingId");

                    b.ToTable("Croppings");
                });

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

            modelBuilder.Entity("CroppingFarm", b =>
                {
                    b.HasOne("DemoApp.Models.Cropping", null)
                        .WithMany()
                        .HasForeignKey("CroppingsCroppingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DemoApp.Models.Farm", null)
                        .WithMany()
                        .HasForeignKey("FarmsFarmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
