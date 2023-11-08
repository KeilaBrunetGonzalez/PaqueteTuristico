using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace PaqueteTuristico.Models
{
    [Table("Hotel_Plan")]
    public class HotelPlan
    {
        public HotelPlan() { 
        this.Hotel = new Hotel();
        this.Season = new Season();
        }
        [Key]
        public int HotelId { get; set; }
        [Key]
        public int SeasonId { get; set; }
      
        [ForeignKey(nameof(HotelId))]
        public Hotel Hotel { get; set; }
        [ForeignKey(nameof(HotelId))]
        public Season Season { get; set; }
    }
}
