using System.ComponentModel.DataAnnotations;

namespace PaqueteTuristico.Dtos
{
    public class TourPackageDTO
    {
        public int PackageId { get; set; }
        public string? ProvinceName { get; set; }
        public string? HotelName { get; set; }
        public string? RoomName { get; set; }
        public string? MealName { get; set; }
        public string? Vehicle { get; set; }
        public int Modality { get; set; }
        public string? UserName { get; set; }
        public int PeopleCant { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Totalprice { get; set; }
        
    }

}

