﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Two.Context;

namespace Two.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220523135905_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Two.Models.Issue", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AutgorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ExecutorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("AutgorId");

                    b.HasIndex("ExecutorId");

                    b.HasIndex("PropertyId");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("Two.Models.Position", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("Two.Models.Priority", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Priorities");
                });

            modelBuilder.Entity("Two.Models.TimeTrackingId", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExecutionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.Property<int>("IssueId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("IssueId");

                    b.ToTable("TimeTrackings");
                });

            modelBuilder.Entity("Two.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("PositionId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Two.Models.Issue", b =>
                {
                    b.HasOne("Two.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("AutgorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Two.Models.User", "Executor")
                        .WithMany()
                        .HasForeignKey("ExecutorId");

                    b.HasOne("Two.Models.Priority", "Priority")
                        .WithMany()
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Executor");

                    b.Navigation("Priority");
                });

            modelBuilder.Entity("Two.Models.TimeTrackingId", b =>
                {
                    b.HasOne("Two.Models.Issue", "Issue")
                        .WithMany("TimeTrackings")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Issue");
                });

            modelBuilder.Entity("Two.Models.User", b =>
                {
                    b.HasOne("Two.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Position");
                });

            modelBuilder.Entity("Two.Models.Issue", b =>
                {
                    b.Navigation("TimeTrackings");
                });
#pragma warning restore 612, 618
        }
    }
}
