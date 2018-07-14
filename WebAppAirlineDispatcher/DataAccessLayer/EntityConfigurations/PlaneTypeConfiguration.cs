using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityConfigurations
{
    public class PlaneTypeConfiguration
    {
        public PlaneTypeConfiguration(EntityTypeBuilder<PlaneType> entityBuilder)
        {
            entityBuilder.HasKey(pt => pt.Id);
            entityBuilder.Property(pt => pt.Model).IsRequired();
            entityBuilder.Property(pt => pt.Seats).IsRequired();
            entityBuilder.Property(pt => pt.Carrying).IsRequired();
        }
    }
}
