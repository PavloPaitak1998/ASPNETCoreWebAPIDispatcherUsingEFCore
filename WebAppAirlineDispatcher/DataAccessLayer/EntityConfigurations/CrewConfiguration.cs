using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityConfigurations
{
    public class CrewConfiguration
    {
        public CrewConfiguration(EntityTypeBuilder<Crew> entityBuilder)
        {
            entityBuilder.HasKey(c => c.Id);
            entityBuilder.Property(c => c.PilotId).IsRequired();
            entityBuilder.HasOne(e => e.Pilot).WithOne(e=>e.Crew).HasForeignKey<Crew>(e=>e.PilotId);

        }
    }
}
