using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaqueteTuristico.Models
{
    [Table("MileageCost")]
    public class MileageCost : Modality
    {
        [Required]
        [Column(TypeName = "money")]
        public decimal cost_per_kilometer { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal cost_per_round_trip { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal cost_per_waiting_hour { get; set; }
    }
}

