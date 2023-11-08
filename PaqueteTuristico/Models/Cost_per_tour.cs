using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaqueteTuristico.Models
{
    [Table("cost_per_tour")]
    public class Cost_per_tour:Modality
    {
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        public string Rout_Description { get; set; } = "";
        [Required]
        public float Route_cost { get; set; }
        [Required]
        public float Round_Trip_cost { get; set; }
    }
}
