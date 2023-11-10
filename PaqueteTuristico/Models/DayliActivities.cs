using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace PaqueteTuristico.Models
{
    [Table("Dayli_Activities")]
    public class DayliActivities
    {
        [Key]
        public int ActivityId { get; set; }
        [Required]
        public int Day {  get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        public string Description { get; set; } = "";
        [Required]
        [Column(TypeName = "time")]
        public TimeOnly Hour {  get; set; }
        [Required]
        public float Price { get; set; }
    }
}
