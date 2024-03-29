﻿// <auto-generated />
using System;
using GCPVDMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GCPVDMS.Migrations.ApplicationDb
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210325204128_adminComment")]
    partial class adminComment
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GCPVDMS.Models.County", b =>
                {
                    b.Property<int>("CountyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountyName")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("CountyState")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("CountyID");

                    b.ToTable("Counties");
                });

            modelBuilder.Entity("GCPVDMS.Models.Drive", b =>
                {
                    b.Property<int>("DriveID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("DriveID");

                    b.ToTable("Drives");
                });

            modelBuilder.Entity("GCPVDMS.Models.Event", b =>
                {
                    b.Property<int>("EventID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("LocationID")
                        .HasColumnType("int");

                    b.Property<int>("NumVolunteersNeeded")
                        .HasColumnType("int");

                    b.Property<int>("NumVolunteersSignedUp")
                        .HasColumnType("int");

                    b.Property<string>("POCEmail")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("POCName")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("POCPhone")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isEventActive")
                        .HasColumnType("bit");

                    b.HasKey("EventID");

                    b.HasIndex("LocationID");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("GCPVDMS.Models.EventRegistration", b =>
                {
                    b.Property<int>("EventRegistrationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventID")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("isLogged")
                        .HasColumnType("bit");

                    b.HasKey("EventRegistrationID");

                    b.HasIndex("EventID", "UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("EventRegistrations");
                });

            modelBuilder.Entity("GCPVDMS.Models.GCPEventTask", b =>
                {
                    b.Property<int>("GCPEventTaskID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventID")
                        .HasColumnType("int");

                    b.Property<int>("GCPTaskID")
                        .HasColumnType("int");

                    b.Property<bool>("isSelected")
                        .HasColumnType("bit");

                    b.HasKey("GCPEventTaskID");

                    b.HasIndex("EventID");

                    b.HasIndex("GCPTaskID");

                    b.ToTable("GCPEventTasks");
                });

            modelBuilder.Entity("GCPVDMS.Models.GCPTask", b =>
                {
                    b.Property<int>("GCPTaskID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TaskName")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("GCPTaskID");

                    b.ToTable("GCPTasks");
                });

            modelBuilder.Entity("GCPVDMS.Models.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("CountyID")
                        .HasColumnType("int");

                    b.Property<string>("LocationName")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("StreetAddress2")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Zip")
                        .HasColumnType("nvarchar(32)")
                        .HasMaxLength(32);

                    b.HasKey("LocationID");

                    b.HasIndex("CountyID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("GCPVDMS.Models.VolunteerGroup", b =>
                {
                    b.Property<int>("VolunteerGroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("VolunteerGroupName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VolunteerGroupID");

                    b.ToTable("VolunteerGroups");
                });

            modelBuilder.Entity("GCPVDMS.Models.VolunteerHour", b =>
                {
                    b.Property<int>("VolunteerHourID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventID")
                        .HasColumnType("int");

                    b.Property<double>("NumberOfHours")
                        .HasColumnType("float");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VolunteerGroupID")
                        .HasColumnType("int");

                    b.Property<string>("adminComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isApproved")
                        .HasColumnType("bit");

                    b.Property<bool>("isDenied")
                        .HasColumnType("bit");

                    b.Property<string>("volunteerDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("volunteerHourDate")
                        .HasColumnType("datetime2");

                    b.HasKey("VolunteerHourID");

                    b.HasIndex("EventID");

                    b.HasIndex("VolunteerGroupID");

                    b.ToTable("VolunteerHours");
                });

            modelBuilder.Entity("GCPVDMS.Models.Event", b =>
                {
                    b.HasOne("GCPVDMS.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GCPVDMS.Models.EventRegistration", b =>
                {
                    b.HasOne("GCPVDMS.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GCPVDMS.Models.GCPEventTask", b =>
                {
                    b.HasOne("GCPVDMS.Models.Event", "Event")
                        .WithMany("EventTasks")
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GCPVDMS.Models.GCPTask", "GCPTask")
                        .WithMany()
                        .HasForeignKey("GCPTaskID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GCPVDMS.Models.Location", b =>
                {
                    b.HasOne("GCPVDMS.Models.County", "County")
                        .WithMany()
                        .HasForeignKey("CountyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GCPVDMS.Models.VolunteerHour", b =>
                {
                    b.HasOne("GCPVDMS.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GCPVDMS.Models.VolunteerGroup", "VolunteerGroup")
                        .WithMany()
                        .HasForeignKey("VolunteerGroupID");
                });
#pragma warning restore 612, 618
        }
    }
}
