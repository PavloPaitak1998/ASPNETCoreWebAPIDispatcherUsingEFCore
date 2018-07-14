
namespace DataAccessLayer.Models
{
    public sealed class PlaneType
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Seats { get; set; }
        public double Carrying { get; set; }

        public Plane Plane { get; set; }
    }
}
