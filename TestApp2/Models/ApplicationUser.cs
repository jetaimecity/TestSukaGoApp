using ElCamino.AspNetCore.Identity.AzureTable.Model;

namespace TestApp2.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
    }
}
