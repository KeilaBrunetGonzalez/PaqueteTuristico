using System.ComponentModel.DataAnnotations;

namespace PaqueteTuristico.Dtos
{
    public class SeasonHotelContract
    {
        public string? HotelName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ConciliationDate { get; set; }
        public DateTime SeasonStartDate { get; set; }
        public string? SeasonName { get; set; }
        public string? RoomType { get; set; }
        public string? MealPlan { get; set; }
        public decimal? ContractPrice { get; set; }        
    }

}

