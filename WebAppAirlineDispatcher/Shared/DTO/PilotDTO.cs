using System;

namespace Shared.DTO
{
    public class PilotDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int? Experience { get; set; }
    }
}
