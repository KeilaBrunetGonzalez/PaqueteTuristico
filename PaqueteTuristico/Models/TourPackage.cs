using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PaqueteTuristico.Models
{
    public class TourPackage
    {
        public TourPackage() {
            this.DayliActivities = new DayliActivities();
            this.Transport = new Transport();
            this.Hotel = new Hotel();   
        }
        [Key]
        public int PackageId { get; set; }
        public int ProvinceId { get; set; }
        public int HotelId { get; set; }
        public int VehicleId { get; set; }
        public int ModalityId { get; set; }
        public int ActivityId { get; set; }

        [Column(TypeName = "date")]
        [Required]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        [Required]
        public DateTime EndDate { get; set; }

        [Column(TypeName = "money")]
        [Required]
        public decimal Totalprice { get; set; }
        [JsonIgnore]
        public Hotel Hotel { get; set; }
        [JsonIgnore]
        public Transport Transport { get; set;}
        [JsonIgnore]
        public DayliActivities DayliActivities { get; set; }

    }
}
