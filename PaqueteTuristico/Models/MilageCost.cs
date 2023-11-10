using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaqueteTuristico.Models
{
    [Table("MileageCost")]
    public class MileageCost : Modality
    {
        [Required]
        public float cost_per_kilometer { get; set; }
        [Required]
        public float cost_per_round_trip { get; set; }
        [Required]
        public float cost_per_waiting_hour { get; set; }
    }
}

