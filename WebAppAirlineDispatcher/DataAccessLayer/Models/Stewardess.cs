using System;

namespace DataAccessLayer.Models
{
    public sealed class Stewardess
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public int CrewId { get; set; }
        public Crew Crew { get; set; }
    }
}
