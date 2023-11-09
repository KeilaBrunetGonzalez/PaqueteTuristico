using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.Xml;

namespace PaqueteTuristico.Models
{
    [Table("Modality")]
    public class Modality
    {
        [Key]
        public virtual int modality_id { get; set; }

    }
}

