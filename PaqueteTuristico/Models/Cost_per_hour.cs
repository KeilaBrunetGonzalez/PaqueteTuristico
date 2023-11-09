using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaqueteTuristico.Models
{
    [Table("Cost_per_hour")]
    public class Cost_per_hour : Modality
    {
        [Required]
        public float CostperHour { get; set; }
        [Required]
        public float CostperKilometerTraveled { get; set; }
        [Required]
        public float ExtraKilometer_cost {  get; set; }
        [Required]
        public float ExtraHour_cost { get; set; }
    }
}
