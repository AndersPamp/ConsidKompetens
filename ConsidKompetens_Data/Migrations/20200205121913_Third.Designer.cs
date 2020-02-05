﻿// <auto-generated />
using System;
using ConsidKompetens_Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConsidKompetens_Data.Migrations
{
    [DbContext(typeof(UserDataContext))]
    [Migration("20200205121913_Third")]
    partial class Third
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConsidKompetens_Core.Models.CompetenceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeUserModelId")
                        .HasColumnType("int");

                    b.Property<int?>("IconId")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeUserModelId");

                    b.HasIndex("IconId");

                    b.ToTable("CompetenceModels");
                });

            modelBuilder.Entity("ConsidKompetens_Core.Models.EmployeeUserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AboutMe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<int>("OfficeId")
                        .HasColumnType("int");

                    b.Property<int?>("OfficeModelId")
                        .HasColumnType("int");

                    b.Property<string>("OwnerID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProfileImageId")
                        .HasColumnType("int");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OfficeModelId");

                    b.HasIndex("ProfileImageId");

                    b.ToTable("EmployeeUsers");
                });

            modelBuilder.Entity("ConsidKompetens_Core.Models.ImageModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ImageModel");
                });

            modelBuilder.Entity("ConsidKompetens_Core.Models.OfficeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<long>("TelephoneNumber")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("OfficeModels");
                });

            modelBuilder.Entity("ConsidKompetens_Core.Models.ProjectModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeUserModelId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int>("Techniques")
                        .HasColumnType("int");

                    b.Property<string>("TimePeriod")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeUserModelId");

                    b.ToTable("ProjectModels");
                });

            modelBuilder.Entity("ConsidKompetens_Core.Models.CompetenceModel", b =>
                {
                    b.HasOne("ConsidKompetens_Core.Models.EmployeeUserModel", null)
                        .WithMany("Competences")
                        .HasForeignKey("EmployeeUserModelId");

                    b.HasOne("ConsidKompetens_Core.Models.ImageModel", "Icon")
                        .WithMany()
                        .HasForeignKey("IconId");
                });

            modelBuilder.Entity("ConsidKompetens_Core.Models.EmployeeUserModel", b =>
                {
                    b.HasOne("ConsidKompetens_Core.Models.OfficeModel", null)
                        .WithMany("Employees")
                        .HasForeignKey("OfficeModelId");

                    b.HasOne("ConsidKompetens_Core.Models.ImageModel", "ProfileImage")
                        .WithMany()
                        .HasForeignKey("ProfileImageId");
                });

            modelBuilder.Entity("ConsidKompetens_Core.Models.ProjectModel", b =>
                {
                    b.HasOne("ConsidKompetens_Core.Models.EmployeeUserModel", null)
                        .WithMany("Projects")
                        .HasForeignKey("EmployeeUserModelId");
                });
#pragma warning restore 612, 618
        }
    }
}
