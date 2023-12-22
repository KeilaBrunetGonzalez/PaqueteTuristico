using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PaqueteTuristico.Models
{
    [Table("Hotel_Plan")]
    public class HotelPlan
    {
        public HotelPlan()
        {
            this.Hotel = new Hotel();
            this.Season = new Season();
            this.Contracts = new HashSet<HotelContract>();
        }
        [Key]
        public int HotelId { get; set; }
        [Key]
        public int SeasonId { get; set; }

        
        [JsonIgnore]
        public Hotel Hotel { get; set; }
        
        [JsonIgnore]
        public Season Season { get; set; }

        [JsonIgnore]
        public ICollection<HotelContract> Contracts { get; set; }
    }
}
