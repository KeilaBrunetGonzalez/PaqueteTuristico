using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PaqueteTuristico.Models
{
    [Table("EContract")]
    public class EContract
    {

        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        [Required]
        public string Desc { get; set; } = "";


        [Column(TypeName = "date")]
        [Required]
        public DateTime StarDate { get; set; } = DateTime.Now;


        [Column(TypeName = "date")]
        [Required]
        public DateTime EndTime { get; set; } = DateTime.MaxValue;

        [Column(TypeName = "date")]
        [Required]
        public DateTime ConcilTime { get; set; } = DateTime.Now;

        [Column(TypeName = "boolean")]
        public bool Enabled { get; set; } = true;
    }
}
