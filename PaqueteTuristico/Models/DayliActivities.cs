using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace PaqueteTuristico.Models
{
    [Table("Dayli_Activities")]
    public class DayliActivities
    {
        public DayliActivities() { 
            
            this.Contract = new ComplementaryContract();
        }
        [Key]
        public int ActivityId { get; set; }
        [Required]
        public int Day { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        public string Description { get; set; } = "";
        
        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Required]
        public int ProvinceId { get; set; }
        [Required]
        public int ContractId { get; set; }
        public ComplementaryContract Contract { get; set; }

        
        
    }
}
