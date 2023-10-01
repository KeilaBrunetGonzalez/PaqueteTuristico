using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaqueteTuristico.Models
{
    [Table("Room")]
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        public string Name { get; set; } = "";

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        public string Description { get; set; } = "";

        
        public int Price { get; set; }

        
        public int? HotelId { get; set; }

        public Hotel? Hotel { get; set; }

    }
}
