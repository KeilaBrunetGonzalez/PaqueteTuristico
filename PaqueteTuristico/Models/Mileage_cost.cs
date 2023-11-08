using System.ComponentModel.DataAnnotations;

namespace PaqueteTuristico.Models
{ 
    public class Mileage_cost:Modality
    {
        [Required]
        public float cost_per_kilometer { get; set; }
        [Required] 
        public float cost_per_round_trip { get; set; }
        [Required]
        public float cost_per_waiting_hour { get; set; }
    }
}
