﻿// <auto-generated />
using System;
using Coffe_Project.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Coffe_Project.Migrations
{
    [DbContext(typeof(Coffe_ProjectContext))]
    [Migration("20230111090512_Distribuitor")]
    partial class Distribuitor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Coffe_Project.Models.Coffe", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("DataFabricatiei")
                        .HasColumnType("datetime2");

                    b.Property<string>("Denumire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DistribuitorID")
                        .HasColumnType("int");

                    b.Property<string>("Origine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("ID");

                    b.HasIndex("DistribuitorID");

                    b.ToTable("Coffe");
                });

            modelBuilder.Entity("Coffe_Project.Models.Distribuitor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("DistribuitorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Distribuitor");
                });

            modelBuilder.Entity("Coffe_Project.Models.Coffe", b =>
                {
                    b.HasOne("Coffe_Project.Models.Distribuitor", "Distribuitor")
                        .WithMany("Coffes")
                        .HasForeignKey("DistribuitorID");

                    b.Navigation("Distribuitor");
                });

            modelBuilder.Entity("Coffe_Project.Models.Distribuitor", b =>
                {
                    b.Navigation("Coffes");
                });
#pragma warning restore 612, 618
        }
    }
}