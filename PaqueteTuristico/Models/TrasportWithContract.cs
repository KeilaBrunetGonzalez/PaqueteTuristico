using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PaqueteTuristico.Models
{
    public class TrasportWithContract
    {
        public TrasportWithContract() {
            this.Transport = new Transport();
            this.Transportation = new TransportationContract();
        }
        public int id { get; set; }
        [JsonIgnore]
        public TransportationContract Transportation { get; set; }

        public int Vehicleid { get; set; }
        public int Modalityid { get; set; }
        [JsonIgnore]
        public Transport Transport { get; set; }
    }
}
