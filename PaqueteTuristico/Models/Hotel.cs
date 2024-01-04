using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PaqueteTuristico.Models
{
    [Table("Hotel")]
    public class Hotel
    {
        public Hotel() { 
            this.Rooms = new HashSet<Room>();
            this.Meals = new HashSet<Meal>();
            this.Plans = new HashSet<HotelPlan>();
            this.TourPackages = new HashSet<TourPackage>(); 
            this.Province = new Province();
        }

        [Key]
        public int HotelId { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        [Required]
        public string Name { get; set; } = ""; 

        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        [Required]
        public string Chain { get; set; } = "";

 
        [Required]
        public int Category { get; set; }

        [Required]
        public int Phone { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        [Required]
        public string Email { get; set; } = "";

        [Required]
        public int NumberOfRooms { get; set; }

        [Required]
        public int ProvinceId {  get; set; }

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
        [JsonIgnore]

        public Province Province { get; set; }
        [JsonIgnore]
        public virtual ICollection<HotelPlan> Plans { get; set; }

        [JsonIgnore]
        public virtual ICollection<Room> Rooms { get; set; }

        [JsonIgnore]
        public virtual ICollection<Meal> Meals { get; set; }

        [JsonIgnore]
        public virtual ICollection<TourPackage> TourPackages { get; set; }


    }
}
