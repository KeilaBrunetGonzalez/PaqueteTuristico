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
        public decimal? CostoPorKilometro { get; set; }
        public decimal? CostoPorKilometroIdaVuelta { get; set; }
        public decimal? CostoPorHorasEspera { get; set; }
        public decimal? CostoPorKilometroRecorrido { get; set; }
        public decimal? CostoPorHoras { get; set; }
        public decimal? CostoPorKilometrosExtras { get; set; }
        public decimal? CostosPorHorasExtras { get; set; }
        public string? DescripcionRecorrido { get; set; }
        public decimal? CostoRecorrido { get; set; }
        public decimal? CostoPorIdaVuelta { get; set; }

    }

}