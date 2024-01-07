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
            this.Contract = new TransportationContract();
            this.TourPackages = new HashSet<TourPackage>();
        }
        [Key] 
        public int ModalityId { get; set; }
        [Key]
        public int VehicleId { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal Transport_Cost { get; set; }
        public int ContractId { get; set; }
        [JsonIgnore]
        public Vehicle Vehicle { get; set; }
        [JsonIgnore]
        public Modality Modality { get; set; }

        [JsonIgnore]
        public virtual TransportationContract Contract { get; set; }
        [JsonIgnore]
        public virtual ICollection<TourPackage> TourPackages { get; set; }

    }
}
