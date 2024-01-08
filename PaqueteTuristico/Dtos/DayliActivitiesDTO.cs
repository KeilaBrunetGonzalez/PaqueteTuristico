using System.ComponentModel.DataAnnotations;

namespace PaqueteTuristico.Dtos
{
    public class DayliActivitiesDTO
    {
        public int ActivityId { get; set; }
        public int Day { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int ProvinceId { get; set; }
        public string? ProvinceName { get; set; }

        public int ContractId {  get; set; }
    }

}

