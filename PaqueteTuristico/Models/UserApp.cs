using Microsoft.AspNetCore.Identity;

namespace PaqueteTuristico.Models
{
    public class UserApp:IdentityUser
    {
        public UserApp() { 
        this.TourPackages = new HashSet<TourPackage>();
        }
        public ICollection<TourPackage> TourPackages { get; set; }
    }
}
