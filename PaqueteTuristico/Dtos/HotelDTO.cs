using System.ComponentModel.DataAnnotations;

namespace PaqueteTuristico.Dtos
{
    public class HotelDTO
    {
        public DateTime Date { get; set; }
        public string? HotelName { get; set; }
        public string? HotelChain { get; set; }
        public string? Province { get; set; }
        public string? Category { get; set; }
        public int Phone { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public int DisNearCity { get; set; }
        public int DisAirport { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfFloors { get; set; }
        public string? ComercializationMode { get; set; }
    }

}
