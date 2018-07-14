using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityConfigurations
{
    public class FlightConfiguration
    {
        public FlightConfiguration(EntityTypeBuilder<Flight> entityBuilder)
        {
            entityBuilder.HasKey(f => f.Id);
            entityBuilder.Property(f => f.Number).IsRequired();
            entityBuilder.Property(f => f.PointOfDeparture).IsRequired();
            entityBuilder.Property(f => f.Destination).IsRequired();
            entityBuilder.Property(f => f.DepartureTime).IsRequired();
            entityBuilder.Property(f => f.DepartureTime).IsRequired();
        }
    }
}
