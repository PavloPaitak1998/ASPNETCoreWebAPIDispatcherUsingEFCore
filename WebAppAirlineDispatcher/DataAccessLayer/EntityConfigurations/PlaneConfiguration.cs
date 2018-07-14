using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityConfigurations
{
    public class PlaneConfiguration
    {
        public PlaneConfiguration(EntityTypeBuilder<Plane> entityBuilder)
        {
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.Name).IsRequired();
            entityBuilder.Property(p => p.ReleaseDate).IsRequired();
            entityBuilder.Property(p => p.LifetimeTicks).IsRequired();
            entityBuilder.HasOne(e => e.PlaneType).WithOne(e => e.Plane).HasForeignKey<Plane>(e => e.PlaneTypeId);

        }
    }
}
