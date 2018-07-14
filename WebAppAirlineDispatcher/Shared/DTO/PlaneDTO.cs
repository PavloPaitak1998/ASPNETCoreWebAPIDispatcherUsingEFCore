using System;

namespace Shared.DTO
{
    public sealed class PlaneDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PlaneTypeId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan Lifetime { get; set; }
    }
}
