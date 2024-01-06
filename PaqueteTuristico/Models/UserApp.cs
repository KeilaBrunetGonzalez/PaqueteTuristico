using Microsoft.AspNetCore.Identity;

namespace PaqueteTuristico.Models
{
    public class UserApp:IdentityUser
    {
        public UserApp() { 
        this.Packages = new HashSet<TourPackage>();
        }
        public ICollection<TourPackage> Packages { get; set; }
    }
}
