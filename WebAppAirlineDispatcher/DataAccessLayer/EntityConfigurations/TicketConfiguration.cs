using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityConfigurations
{
    public class TicketConfiguration
    {
        public TicketConfiguration(EntityTypeBuilder<Ticket> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Price).IsRequired();
            entityBuilder.HasOne(e => e.Flight).WithMany(e => e.Tickets).HasForeignKey(e => e.FlightId);
        }
    }
}
