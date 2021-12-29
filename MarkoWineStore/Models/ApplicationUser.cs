using Microsoft.AspNetCore.Identity;

namespace MarkoWineStore.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string deliveryAddress { get; set; }
        public string mobilePhone { get; set; }
    }
}
