﻿// <auto-generated />
using System;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(DispatcherContext))]
    [Migration("20180714175052_initialization")]
    partial class initialization
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccessLayer.Models.Crew", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PilotId");

                    b.HasKey("Id");

                    b.HasIndex("PilotId")
                        .IsUnique();

                    b.ToTable("Crews");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Departure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CrewId");

                    b.Property<int>("FlightId");

                    b.Property<int>("FlightNumber");

                    b.Property<int>("PlaneId");

                    b.Property<DateTime>("Time");

                    b.HasKey("Id");

                    b.HasIndex("CrewId")
                        .IsUnique();

                    b.HasIndex("FlightId")
                        .IsUnique();

                    b.HasIndex("PlaneId")
                        .IsUnique();

                    b.ToTable("Departures");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DepartureTime");

                    b.Property<string>("Destination");

                    b.Property<DateTime>("DestinationTime");

                    b.Property<int>("Number");

                    b.Property<string>("PointOfDeparture");

                    b.HasKey("Id");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Pilot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<int>("Experience");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("Pilots");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Plane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("LifetimeTicks");

                    b.Property<string>("Name");

                    b.Property<int>("PlaneTypeId");

                    b.Property<DateTime>("ReleaseDate");

                    b.HasKey("Id");

                    b.HasIndex("PlaneTypeId")
                        .IsUnique();

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("DataAccessLayer.Models.PlaneType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Carrying");

                    b.Property<string>("Model");

                    b.Property<int>("Seats");

                    b.HasKey("Id");

                    b.ToTable("PlaneTypes");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Stewardess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<int>("CrewId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.HasIndex("CrewId");

                    b.ToTable("Stewardesses");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FlightId");

                    b.Property<int>("FlightNumber");

                    b.Property<double>("Price");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("DataAccessLayer.Models.Crew", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Pilot", "Pilot")
                        .WithOne("Crew")
                        .HasForeignKey("DataAccessLayer.Models.Crew", "PilotId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataAccessLayer.Models.Departure", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Crew", "Crew")
                        .WithOne("Departure")
                        .HasForeignKey("DataAccessLayer.Models.Departure", "CrewId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataAccessLayer.Models.Flight", "Flight")
                        .WithOne("Departure")
                        .HasForeignKey("DataAccessLayer.Models.Departure", "FlightId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataAccessLayer.Models.Plane", "Plane")
                        .WithOne("Departure")
                        .HasForeignKey("DataAccessLayer.Models.Departure", "PlaneId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataAccessLayer.Models.Plane", b =>
                {
                    b.HasOne("DataAccessLayer.Models.PlaneType", "PlaneType")
                        .WithOne("Plane")
                        .HasForeignKey("DataAccessLayer.Models.Plane", "PlaneTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataAccessLayer.Models.Stewardess", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Crew", "Crew")
                        .WithMany("Stewardesses")
                        .HasForeignKey("CrewId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataAccessLayer.Models.Ticket", b =>
                {
                    b.HasOne("DataAccessLayer.Models.Flight", "Flight")
                        .WithMany("Tickets")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
