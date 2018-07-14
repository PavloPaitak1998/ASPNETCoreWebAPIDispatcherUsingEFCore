using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public sealed class Crew
    {
        public int Id { get; set; }

        public int PilotId { get; set; }
        public Pilot Pilot { get; set; }

        public ICollection<Stewardess> Stewardesses { get; set; }

        public Departure Departure { get; set; }
    }
}
