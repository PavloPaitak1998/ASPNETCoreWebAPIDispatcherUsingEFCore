using DataAccessLayer.EntityConfigurations;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data
{
    public class DispatcherContext:DbContext
    {
        public DispatcherContext(DbContextOptions<DispatcherContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new FlightConfiguration(modelBuilder.Entity<Flight>());
            new TicketConfiguration(modelBuilder.Entity<Ticket>());
            new DepartureConfiguration(modelBuilder.Entity<Departure>());
            new StewardessConfiguration(modelBuilder.Entity<Stewardess>());
            new PilotConfiguration(modelBuilder.Entity<Pilot>());
            new CrewConfiguration(modelBuilder.Entity<Crew>());
            new PlaneTypeConfiguration(modelBuilder.Entity<PlaneType>());
            new PlaneConfiguration(modelBuilder.Entity<Plane>());

        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Departure> Departures { get; set; }
        public DbSet<Stewardess> Stewardesses { get; set; }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<PlaneType> PlaneTypes { get; set; }

    }
}
