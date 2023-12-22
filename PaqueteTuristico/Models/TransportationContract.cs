using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaqueteTuristico.Models
{
    [Table("TransportationContract")]
    public class TransportationContract: EContract
    {
        public TransportationContract() {
           this.Transports = new HashSet<Transport>(); 
        }
        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        [Required]
        public string TransportationProvider { get; set; } = "";

        [Required]
        public int IncluedVehicles { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        [Required]
        
        public ICollection<Transport> Transports { get; set; }
    }
}
