using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaqueteTuristico.Models
{
    [Table("Hotel_Plan")]
    public class HotelPlan
    {
        [Key]
        public int HotelId { get; set; }
        [Key]
        public int SeasonId { get; set; }
    }
}
