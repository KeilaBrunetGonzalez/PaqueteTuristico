using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaqueteTuristico.Models
{
    [Table("CostPerHour")]
    public class CostPerHour : Modality
    {
        [Required]
        [Column(TypeName = "money")]
        public decimal cost_per_hour { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal cost_per_kilometer_traveled { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal extra_kilometer_cost { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal extra_hour_cost { get; set; }
        
    }

}