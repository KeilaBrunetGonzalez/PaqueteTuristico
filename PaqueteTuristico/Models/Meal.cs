using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaqueteTuristico.Models
{
    [Table("Meal")]
    public class Meal
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        public string Name { get; set; } = "";

        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        [Required]
        public string Description { get; set; } = "";

        [Column(TypeName = "money")]
        [Required]
        public decimal Price { get; set; }

        [Required]
        [ForeignKey(nameof(Meal))]   
        public int HotelId { get; set; }

    }
}
