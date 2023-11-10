using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaqueteTuristico.Models
{
    [Table("Hotel")]
    public class Hotel
    {
        public Hotel() { 
            this.Rooms = new HashSet<Room>();
            this.Meals = new HashSet<Meal>();
            this.Plans = new HashSet<HotelPlan>();
        }

        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        [Required]
        public string Name { get; set; } = "";

        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        [Required]
        public string Chain { get; set; } = "";

        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        [Required]
        public string Province { get; set; } = "";

        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        [Required]
        public string Category { get; set; } = "";

        [Required]
        public int Phone { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        [Required]
        public string Email { get; set; } = "";

        [Required]
        public int NumberOfRooms { get; set; }


        [Required]
        public int DisNearCity { get; set; }

        [Required]
        public int DisAirport { get; set; }

        [Required]
        public int NumberOfFloors { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        [Required]
        public string Address { get; set; } = "";

        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        [Required]
        public string ComercializationMode { get; set; } = "";

        [Column(TypeName = "money")]
        [Required]
        public decimal Price { get; set; }

        [Column(TypeName = "boolean")]
        public bool Enabled { get; set; } = true;
        public ICollection<HotelPlan> Plans { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Meal> Meals { get; set; }    

    }
}
