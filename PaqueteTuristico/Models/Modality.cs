using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.Xml;
using System.Text.Json.Serialization;

namespace PaqueteTuristico.Models
{
    [Table("Modality")]
    public class Modality
    {
        public Modality() {
            this.Transports = new HashSet<Transport>(); 
        }
        [Key]
        public virtual int ModalityId { get; set; }
        [Required]
        [Column(TypeName = "varhar")]
        public virtual string Type { get; set; } = string.Empty;
        [JsonIgnore]
        public virtual ICollection<Transport> Transports { get; set; }

    }
}

