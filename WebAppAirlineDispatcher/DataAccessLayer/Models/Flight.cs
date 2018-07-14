using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public sealed class Flight
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string PointOfDeparture { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Destination { get; set; }
        public DateTime DestinationTime { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

        public Departure Departure { get; set; }
    }
}
