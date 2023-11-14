using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PaqueteTuristico.Models
{
    public class Transport
    {
        public Transport() {
            this.Modality = new Modality();
            this.Vehicle = new Vehicle();
        }
        [Key] 
        public int ModalityId { get; set; }
        [Key]
        public int VehicleId { get; set; }
        [Required] 
        public float Transport_Cost { get; set; }
        [JsonIgnore]
        public Vehicle Vehicle { get; set; }
        [JsonIgnore]
        public Modality Modality { get; set; }

    }
}
