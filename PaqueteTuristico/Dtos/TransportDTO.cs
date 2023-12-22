using System.ComponentModel.DataAnnotations;

namespace PaqueteTuristico.Dtos
{
    public class TransportDTO
    {
        public int ModalityId { get; set; }
        public int VehicleId { get; set; }
        public decimal Transport_Cost { get; set; }
    }
}
