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
    [Migration("20230327110649_GnerateInitialTables")]
    partial class GnerateInitialTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CVApplicationsManager.Models.AppllicantModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("DegreeId")
                        .HasColumnType("int");

                    b.Property<int?>("DegreesModel")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

                    b.ToTable("Applicants");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AppllicantModel");
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
                });

            modelBuilder.Entity("CVApplicationsManager.Models.CvApplicationModel", b =>
                {
                    b.HasBaseType("CVApplicationsManager.Models.AppllicantModel");

                    b.Property<string>("CvBlob")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("CvApplicationModel");
                });

            modelBuilder.Entity("CVApplicationsManager.Models.AppllicantModel", b =>
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
