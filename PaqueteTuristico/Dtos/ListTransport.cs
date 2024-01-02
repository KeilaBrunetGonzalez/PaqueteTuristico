using System.ComponentModel.DataAnnotations;

namespace PaqueteTuristico.Dtos
{
    public class ListTransport
    {
        public string? PrestarioTransporte { get; set; }
        public DateTime FechaInicioContrato { get; set; }
        public DateTime? FechaTerminacionContrato { get; set; }
        public DateTime? FechaConciliacionContrato { get; set; }
        public string? Chapa { get; set; }
        public string? Marca { get; set; }
        public int CapacidadSinEquipajes { get; set; }
        public int CapacidadConEquipajes { get; set; }
        public int CapacidadTotal { get; set; }
        public int AnnoFabricacion { get; set; }
        public float? CostoPorKilometro { get; set; }
        public float? CostoPorKilometroIdaVuelta { get; set; }
        public float? CostoPorHorasEspera { get; set; }
        public float? CostoPorKilometroRecorrido { get; set; }
        public float? CostoPorHoras { get; set; }
        public float? CostoPorKilometrosExtras { get; set; }
        public float? CostosPorHorasExtras { get; set; }
        public string? DescripcionRecorrido { get; set; }
        public float? CostoRecorrido { get; set; }
        public float? CostoPorIdaVuelta { get; set; }

    }

}