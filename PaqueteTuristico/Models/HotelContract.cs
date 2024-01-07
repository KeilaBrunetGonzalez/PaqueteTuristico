using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PaqueteTuristico.Models
{
    [Table("HotelContract")]
    public class HotelContract: EContract
    {
        public HotelContract() {
            this.Plan = new HotelPlan();
        }
        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        [Required]
        public string Address { get; set; } = "";

        [Column(TypeName = "money")]
        [Required]
        public decimal HotelTotalPrice { get; set; } = 0;
        public int Seasonid { get; set; }
        public int Hotelid { get; set; }
        [JsonIgnore]
        public HotelPlan Plan { get; set; } 

    }
}
