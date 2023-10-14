using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaqueteTuristico.Models
{
    [Table("Season")]
    public class Season
    {
        [Key]
        
        public int SeasonId { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        public string SeasonName { get; set; } = " ";
        [Required]
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Required]
        public ICollection<HotelPlan>? HotelPlans { get; set; }
    }
}
