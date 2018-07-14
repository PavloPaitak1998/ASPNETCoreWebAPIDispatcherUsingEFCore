using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityConfigurations
{
    public class DepartureConfiguration
    {
        public DepartureConfiguration(EntityTypeBuilder<Departure> entityBuilder)
        {
            entityBuilder.HasKey(d => d.Id);
            entityBuilder.Property(d => d.Time).IsRequired();
            entityBuilder.HasOne(e => e.Flight).WithOne(e => e.Departure).HasForeignKey<Departure>(e => e.FlightId);
            entityBuilder.HasOne(e => e.Crew).WithOne(e => e.Departure).HasForeignKey<Departure>(e => e.CrewId);
            entityBuilder.HasOne(e => e.Plane).WithOne(e => e.Departure).HasForeignKey<Departure>(e => e.PlaneId);

        }
    }
}
