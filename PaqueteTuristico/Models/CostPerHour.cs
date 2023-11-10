using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaqueteTuristico.Models
{
    [Table("CostPerHour")]
    public class CostPerHour : Modality
    {
        [Required]
        public float cost_per_hour { get; set; }
        [Required]
        public float cost_per_kilometer_traveled { get; set; }
        [Required]
        public float extra_kilometer_cost { get; set; }
        [Required]
        public float extra_hour_cost { get; set; }
    }

}