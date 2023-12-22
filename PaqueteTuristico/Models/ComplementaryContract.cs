using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;

namespace PaqueteTuristico.Models
{
    [Table("ComplementaryContract")]
    public class ComplementaryContract : EContract
    {
        public ComplementaryContract() { 

            this.DayliActivities = new HashSet<DayliActivities>();
        }
        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        [Required]
        public string ServiceType { get; set; } = "";

        [Column(TypeName = "money")]
        [Required]
        public decimal CostPerPerson { get; set; } = 0;


        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        [Required]
        public string ComplementaryServiceProvince { get; set; } = "";

        public ICollection<DayliActivities> DayliActivities { get; set; }
    }
}
