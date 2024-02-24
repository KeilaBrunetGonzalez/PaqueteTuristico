using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;
using System.Text.Json.Serialization;

namespace PaqueteTuristico.Models
{
    [Table("ComplementaryContract")]
    public class ComplementaryContract : EContract
    {
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
    }

}

