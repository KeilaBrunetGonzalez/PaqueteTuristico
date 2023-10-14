using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaqueteTuristico.Models
{
    [Table("Hotel")]
    public class Hotel
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        [Required]
        public string Name { get; set; } = "";

        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        [Required]
        public string Description { get; set; } = "";

        [Required]
        public int Price { get; set; }

        public ICollection<HotelPlan>?Plans { get; set; }    
        public ICollection<Room>? Rooms { get; set; }
        public ICollection<Meal>? Meals { get; set; }    
    }
}
