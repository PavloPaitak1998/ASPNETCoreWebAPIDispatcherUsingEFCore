using System;

namespace DataAccessLayer.Models
{
    public sealed class Departure
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }

        public int FlightNumber { get; set; }
        public int FlightId { get; set; }
        public Flight Flight { get; set; }

        public int CrewId { get; set; }
        public Crew Crew { get; set; }

        public int PlaneId { get; set; }
        public Plane Plane { get; set; }
    }
}
