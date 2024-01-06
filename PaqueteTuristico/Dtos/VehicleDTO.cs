using System.ComponentModel.DataAnnotations;

namespace PaqueteTuristico.Dtos
{
    public class VehicleDTO
    {
        public int VehicleId { get; set; }
        public string? License_Plate_Number { get; set; }
        public string? Brand { get; set; }
        public int Capacity_Without_Equipement { get; set; }
        public int Capacity_With_Equipement { get; set; }
        public int Total_Capacity { get; set; }
        public int Year_of_Manufacture { get; set; }
        public string? Manufacturing_Mode { get; set; }
        public string? ProvinceName { get; set; }
    }

}

