using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityConfigurations
{
    public class StewardessConfiguration
    {
        public StewardessConfiguration(EntityTypeBuilder<Stewardess> entityBuilder)
        {
            entityBuilder.HasKey(s => s.Id);
            entityBuilder.Property(s => s.FirstName).IsRequired();
            entityBuilder.Property(s => s.LastName).IsRequired();
            entityBuilder.Property(s => s.BirthDate).IsRequired();
            entityBuilder.HasOne(e => e.Crew).WithMany(e => e.Stewardesses).HasForeignKey(e => e.CrewId);

        }
    }
}
