using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PaqueteTuristico.Models
{
    [Table("vehicles")]
    public class Vehicle
    {
        public Vehicle()
        {
            this.Transports = new HashSet<Transport>();
        }
        [Key]
        public int VehicleId { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        public string License_Plate_Number { get; set; } = "";
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        public string Brand { get; set; } = "";
        [Required]
        public int Capacity_Without_Equipement { get; set; }
        [Required]
        public int Capacity_With_Equipement { get; set; }
        [Required]
        public int Total_Capacity { get; set; }
        [Required]
        public int Year_of_Manufacture { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        public string Manufacturing_Mode { get; set; } = "";
        [JsonIgnore]
        public ICollection<Transport> Transports { get; set; }
    }
}
