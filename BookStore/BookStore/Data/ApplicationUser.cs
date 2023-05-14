using Microsoft.AspNetCore.Identity;

namespace BookStore.Data
{
    public class ApplicationUser :IdentityUser
    {
        /// <summary>
        /// First name of the user
        /// </summary>
        [PersonalData]
        public string Firstname { get; set; }
        /// <summary>
        /// Last name of the user
        /// </summary>
        [PersonalData]
        public string Lastname { get; set; }
        /// <summary>
        /// Birth date of the user
        /// </summary>
        [PersonalData]
        public DateTime BirthDate { get; set; }
    }
}
