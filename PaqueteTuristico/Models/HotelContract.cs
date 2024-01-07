using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PaqueteTuristico.Models
{
    [Table("HotelContract")]
    public class HotelContract: EContract
    {

        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        [Required]
        public string Address { get; set; } = "";

        [Column(TypeName = "money")]
        [Required]
        public decimal HotelTotalPrice { get; set; } = 0;


    }
}
