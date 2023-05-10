using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Author
{
    public class AddAuthorViewModel
    {
        [Required(ErrorMessage = "Please fill in the first name.")]
        [MaxLength(255)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please fill in the last name.")]
        [MaxLength(255)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please fill in the birth date.")]
        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }
    }
}
