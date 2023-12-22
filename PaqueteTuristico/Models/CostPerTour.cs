using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaqueteTuristico.Models
{
    [Table("CostPerTour")]
    public class CostPerTour : Modality
    {
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        public string rout_description { get; set; } = "";
        [Required]
        [Column(TypeName = "money")]
        public decimal route_cost { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal round_trip_cost { get; set; }
    }
}
