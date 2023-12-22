using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PaqueteTuristico.Models
{
    public class Province
    {
        public Province() {
            this.DaylActivities = new HashSet<DayliActivities>();
            this.Vehicles = new HashSet<Vehicle>();
            this.Hotels = new HashSet<Hotel>();
        }
        [Key]
        public int ProvinceId { get; set; }
        [Required]
        [StringLength(50)]
        public string ProvinceName { get; set; } = "";

        [JsonIgnore]
        public virtual ICollection<Hotel> Hotels { get; set; }
        [JsonIgnore]
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        [JsonIgnore]
        public virtual ICollection<DayliActivities> DaylActivities { get; set; }    
    }
}
