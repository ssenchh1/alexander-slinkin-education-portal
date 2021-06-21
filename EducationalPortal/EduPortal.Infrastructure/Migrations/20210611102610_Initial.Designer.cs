﻿// <auto-generated />
using System;
using EduPortal.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EduPortal.Infrastructure.Migrations
{
    [DbContext(typeof(EducationalPortalContext))]
    [Migration("20210611102610_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EduPortal.Domain.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int?>("MentorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MentorId");

                    b.HasIndex("StudentId");

                    b.HasIndex("StudentId1");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("EduPortal.Domain.Models.Materials.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<int?>("MentorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("MentorId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("EduPortal.Domain.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int?>("MaterialId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId");

                    b.HasIndex("UserId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("EduPortal.Domain.Models.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EduPortal.Domain.Models.Materials.Article", b =>
                {
                    b.HasBaseType("EduPortal.Domain.Models.Materials.Material");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("EduPortal.Domain.Models.Materials.DigitalBook", b =>
                {
                    b.HasBaseType("EduPortal.Domain.Models.Materials.Material");

                    b.Property<string>("Format")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.ToTable("DigitalBooks");
                });

            modelBuilder.Entity("EduPortal.Domain.Models.Materials.VideoMaterial", b =>
                {
                    b.HasBaseType("EduPortal.Domain.Models.Materials.Material");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<int>("Quality")
                        .HasColumnType("int");

                    b.ToTable("VideoMaterials");
                });

            modelBuilder.Entity("EduPortal.Domain.Models.Users.Mentor", b =>
                {
                    b.HasBaseType("EduPortal.Domain.Models.Users.User");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable("Mentors");
                });

            modelBuilder.Entity("EduPortal.Domain.Models.Users.Student", b =>
                {
                    b.HasBaseType("EduPortal.Domain.Models.Users.User");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EduPortal.Domain.Models.Course", b =>
                {
                    b.HasOne("EduPortal.Domain.Models.Users.Mentor", null)
                        .WithMany("CreatedCourses")
                        .HasForeignKey("MentorId");

                    b.HasOne("EduPortal.Domain.Models.Users.Student", null)
                        .WithMany("Courses")
                        .HasForeignKey("StudentId");

                    b.HasOne("EduPortal.Domain.Models.Users.Student", null)
                        .WithMany("FinishedCourses")
                        .HasForeignKey("StudentId1");
                });

            modelBuilder.Entity("EduPortal.Domain.Models.Materials.Material", b =>
                {
                    b.HasOne("EduPortal.Domain.Models.Course", null)
                        .WithMany("Materials")
                        .HasForeignKey("CourseId");

                    b.HasOne("EduPortal.Domain.Models.Users.Mentor", null)
                        .WithMany("CreatedMaterials")
                        .HasForeignKey("MentorId");
                });

            modelBuilder.Entity("EduPortal.Domain.Models.Skill", b =>
                {
                    b.HasOne("EduPortal.Domain.Models.Materials.Material", null)
                        .WithMany("ProvidedSkills")
                        .HasForeignKey("MaterialId");

                    b.HasOne("EduPortal.Domain.Models.Users.User", null)
                        .WithMany("Skills")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EduPortal.Domain.Models.Materials.Article", b =>
                {
                    b.HasOne("EduPortal.Domain.Models.Materials.Material", null)
                        .WithOne()
                        .HasForeignKey("EduPortal.Domain.Models.Materials.Article", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EduPortal.Domain.Models.Materials.DigitalBook", b =>
                {
                    b.HasOne("EduPortal.Domain.Models.Materials.Material", null)
                        .WithOne()
                        .HasForeignKey("EduPortal.Domain.Models.Materials.DigitalBook", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EduPortal.Domain.Models.Materials.VideoMaterial", b =>
                {
                    b.HasOne("EduPortal.Domain.Models.Materials.Material", null)
                        .WithOne()
                        .HasForeignKey("EduPortal.Domain.Models.Materials.VideoMaterial", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EduPortal.Domain.Models.Users.Mentor", b =>
                {
                    b.HasOne("EduPortal.Domain.Models.Users.User", null)
                        .WithOne()
                        .HasForeignKey("EduPortal.Domain.Models.Users.Mentor", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EduPortal.Domain.Models.Users.Student", b =>
                {
                    b.HasOne("EduPortal.Domain.Models.Users.User", null)
                        .WithOne()
                        .HasForeignKey("EduPortal.Domain.Models.Users.Student", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EduPortal.Domain.Models.Course", b =>
                {
                    b.Navigation("Materials");
                });

            modelBuilder.Entity("EduPortal.Domain.Models.Materials.Material", b =>
                {
                    b.Navigation("ProvidedSkills");
                });

            modelBuilder.Entity("EduPortal.Domain.Models.Users.User", b =>
                {
                    b.Navigation("Skills");
                });

            modelBuilder.Entity("EduPortal.Domain.Models.Users.Mentor", b =>
                {
                    b.Navigation("CreatedCourses");

                    b.Navigation("CreatedMaterials");
                });

            modelBuilder.Entity("EduPortal.Domain.Models.Users.Student", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("FinishedCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
