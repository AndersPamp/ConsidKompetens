﻿// <auto-generated />
using System;
using ConsidKompetens_Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConsidKompetens_Data.Migrations.ProfileData
{
    [DbContext(typeof(DataDbContext))]
    [Migration("20200214085535_secundo")]
    partial class secundo
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

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<int?>("IconId")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProfileModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IconId");

                    b.HasIndex("ProfileModelId");

                    b.ToTable("CompetenceModels");
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

            modelBuilder.Entity("ConsidKompetens_Core.Models.LinkModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("FacebookUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstagramUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkedInUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("TwitterUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LinkModel");
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

            modelBuilder.Entity("ConsidKompetens_Core.Models.ProfileModel", b =>
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

                    b.Property<int?>("LinksId")
                        .HasColumnType("int");

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

                    b.HasIndex("LinksId");

                    b.HasIndex("OfficeModelId");

                    b.HasIndex("ProfileImageId");

                    b.ToTable("ProfileModels");
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

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProfileModelId")
                        .HasColumnType("int");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int>("Techniques")
                        .HasColumnType("int");

                    b.Property<string>("TimePeriod")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProfileModelId");

                    b.ToTable("ProjectModels");
                });

            modelBuilder.Entity("ConsidKompetens_Core.Models.CompetenceModel", b =>
                {
                    b.HasOne("ConsidKompetens_Core.Models.ImageModel", "Icon")
                        .WithMany()
                        .HasForeignKey("IconId");

                    b.HasOne("ConsidKompetens_Core.Models.ProfileModel", null)
                        .WithMany("Competences")
                        .HasForeignKey("ProfileModelId");
                });

            modelBuilder.Entity("ConsidKompetens_Core.Models.ProfileModel", b =>
                {
                    b.HasOne("ConsidKompetens_Core.Models.LinkModel", "Links")
                        .WithMany()
                        .HasForeignKey("LinksId");

                    b.HasOne("ConsidKompetens_Core.Models.OfficeModel", null)
                        .WithMany("Employees")
                        .HasForeignKey("OfficeModelId");

                    b.HasOne("ConsidKompetens_Core.Models.ImageModel", "ProfileImage")
                        .WithMany()
                        .HasForeignKey("ProfileImageId");
                });

            modelBuilder.Entity("ConsidKompetens_Core.Models.ProjectModel", b =>
                {
                    b.HasOne("ConsidKompetens_Core.Models.ProfileModel", null)
                        .WithMany("Projects")
                        .HasForeignKey("ProfileModelId");
                });
#pragma warning restore 612, 618
        }
    }
}
