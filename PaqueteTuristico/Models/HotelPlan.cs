    using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace PaqueteTuristico.Models
{
    [Table("Hotel_Plan")]
    public class HotelPlan
    {

        [Key]
        [ForeignKey(nameof(HotelPlan))]
        public int HotelId { get; set; }

        [Key]
        [ForeignKey(nameof(Season))]
        public int SeasonId { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal TotalPrice;

    }
}
