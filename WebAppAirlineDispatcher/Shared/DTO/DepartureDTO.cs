using System;

namespace Shared.DTO
{
    public sealed class DepartureDTO
    {
        public int Id { get; set; }
        public int FlightNumber { get; set; }
        public DateTime Time { get; set; }
        public int FlightId { get; set; }
        public int CrewId { get; set; }
        public int PlaneId { get; set; }
    }
}
