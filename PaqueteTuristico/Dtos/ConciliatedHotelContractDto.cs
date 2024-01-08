using System.ComponentModel.DataAnnotations;

namespace PaqueteTuristico.Dtos
{
    public class ConciliatedHotelContractDto
    {
        public string? HotelName { get; set; }
        public string? HotelChain { get; set; }
        public string? Province { get; set; }
        public string? Address { get; set; }
        public int? Category { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ConciliationDate { get; set; }
        public string? Description { get; set; }
        public List<string>? RoomTypes { get; set; }
        public List<string>? MealPlans { get; set; }
        public decimal? ContractPrice { get; set; }
    }

}

