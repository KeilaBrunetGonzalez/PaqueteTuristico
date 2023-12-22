using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PaqueteTuristico.Models
{
    public class Transport
    {
        public Transport() {
            this.Modality = new Modality();
            this.Vehicle = new Vehicle();
            this.Contract = new HashSet<TransportationContract>();
            this.TourPackages = new HashSet<TourPackage>();
        }
        [Key] 
        public int ModalityId { get; set; }
        [Key]
        public int VehicleId { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal Transport_Cost { get; set; }
        [JsonIgnore]
        public Vehicle Vehicle { get; set; }
        [JsonIgnore]
        public Modality Modality { get; set; }

        public virtual ICollection<TransportationContract> Contract { get; set; }
        public virtual ICollection<TourPackage> TourPackages { get; set; }

    }
}
