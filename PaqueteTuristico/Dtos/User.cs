using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PaqueteTuristico.Dtos
{
    public class User
    {

        public int Id { get; set; }


        public string UserName { get; set; } = "";


        public string Password { get; set; } = "";

        public string Email { get; set; } = "";
    }
}
