using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PaqueteTuristico.Models
{
    [Table("Season")]
    public class Season
    {
        public Season()
        {
            this.Plans = new HashSet<HotelPlan>();
        }
        [Key]
        public int SeasonId { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        public string SeasonName { get; set; } = "";
        [Required]
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [JsonIgnore]
        public ICollection<HotelPlan> Plans { get; set; }
    }
}
