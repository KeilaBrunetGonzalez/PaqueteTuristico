using System.ComponentModel.DataAnnotations;

namespace PaqueteTuristico.Models
{
    public class Room
    {
        public int Id { get; set; }
        [Key]
        public string Name { get; set; } = "";
        [Required]
        public string Description { get; set; } = "";

        [Required]
        public int Price { get; set; }

        [Required]
        public int? HotelId { get; set; }

        [Required]
        public Hotel? Hotel { get; set; }

    }
}
