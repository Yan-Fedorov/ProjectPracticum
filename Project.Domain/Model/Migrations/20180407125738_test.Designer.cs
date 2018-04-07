﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Project.Domain.Model;
using System;

namespace Project.Domain.Model.Migrations
{
    [DbContext(typeof(ModelContext))]
    [Migration("20180407125738_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("Project.Domain.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Contacts");

                    b.Property<string>("Info");

                    b.Property<string>("Name");

                    b.Property<string>("SomeProp");

                    b.HasKey("Id");

                    b.ToTable("Companys");
                });

            modelBuilder.Entity("Project.Domain.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CompanyId");

                    b.Property<DateTime>("EndTime");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartTime");

                    b.Property<string>("Vacancy");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Project.Domain.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CourseId");

                    b.Property<string>("Info");

                    b.Property<int>("Points");

                    b.Property<string>("answers");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Project.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Project.Domain.Course", b =>
                {
                    b.HasOne("Project.Domain.Company")
                        .WithMany("Courses")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("Project.Domain.Task", b =>
                {
                    b.HasOne("Project.Domain.Course")
                        .WithMany("Tasks")
                        .HasForeignKey("CourseId");
                });
#pragma warning restore 612, 618
        }
    }
}
