using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityConfigurations
{
    public class PilotConfiguration
    {
        public PilotConfiguration(EntityTypeBuilder<Pilot> entityBuilder)
        {
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.FirstName).IsRequired();
            entityBuilder.Property(p => p.LastName).IsRequired();
            entityBuilder.Property(p => p.BirthDate).IsRequired();
            entityBuilder.Property(p => p.Experience).IsRequired();
        }
    }
}
