﻿// <auto-generated />
using System;
using CVApplicationsManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CVApplicationsManager.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230329070519_SeedsDegrees")]
    partial class SeedsDegrees
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CVApplicationsManager.Models.CvApplicationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CvBlob")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DegreeId")
                        .HasColumnType("int");

                    b.Property<int?>("DegreesModel")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DegreesModel");

                    b.ToTable("CvApplications");
                });

            modelBuilder.Entity("CVApplicationsManager.Models.DegreesModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DegreeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Degrees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DegreeName = "Secondary"
                        },
                        new
                        {
                            Id = 2,
                            DegreeName = "Bachelor's"
                        },
                        new
                        {
                            Id = 3,
                            DegreeName = "Master's"
                        },
                        new
                        {
                            Id = 4,
                            DegreeName = "PhD"
                        });
                });

            modelBuilder.Entity("CVApplicationsManager.Models.CvApplicationModel", b =>
                {
                    b.HasOne("CVApplicationsManager.Models.DegreesModel", "DegreeName")
                        .WithMany()
                        .HasForeignKey("DegreesModel");

                    b.Navigation("DegreeName");
                });
#pragma warning restore 612, 618
        }
    }
}
