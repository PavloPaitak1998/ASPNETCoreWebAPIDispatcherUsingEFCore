
namespace DataAccessLayer.Models
{
    public sealed class Ticket
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int FlightNumber { get; set; }
        public int FlightId { get; set; }

        public Flight Flight { get; set; }
    }
}
