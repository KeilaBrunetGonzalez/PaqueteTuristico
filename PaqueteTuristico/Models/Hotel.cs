using System.ComponentModel.DataAnnotations;

namespace PaqueteTuristico.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "";
        [Required]
        public string Description { get; set; } = "";

        [Required]
        public int Price { get; set; }
        

        public ICollection<Room>? Rooms { get; set; }
        public ICollection<Meal>? Meals { get; set; }    
    }
}
