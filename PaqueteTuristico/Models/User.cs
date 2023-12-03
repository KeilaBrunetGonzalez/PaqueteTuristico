using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PaqueteTuristico.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        [Required]
        public string Name { get; set; } = "";

        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        [Required]
        public string PasswordHash { get; set; } = "";

        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        [Required]
        public string PasswordSalt { get; set; } = "";

        [Column(TypeName = "varchar")]
        [MaxLength(100)]
        [Required]
        public string Gmail { get; set; } = "";
    }
}
