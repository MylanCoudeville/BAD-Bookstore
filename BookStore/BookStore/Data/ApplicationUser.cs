using Microsoft.AspNetCore.Identity;

namespace BookStore.Data
{
    public class ApplicationUser :IdentityUser
    {
        [PersonalData]
        public string Firstname { get; set; }
        [PersonalData]
        public string Lastname { get; set; }
        [PersonalData]
        public DateTime BirthDate { get; set; }
    }
}
