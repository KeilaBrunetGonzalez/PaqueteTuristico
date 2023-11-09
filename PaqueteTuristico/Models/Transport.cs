using System.ComponentModel.DataAnnotations;

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
        public Vehicle Vehicle { get; set; }
        public Modality Modality { get; set; }

    }
}
