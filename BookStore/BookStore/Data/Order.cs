using System.ComponentModel.DataAnnotations;

namespace BookStore.Data
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Fill in your first name")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Fill in your last name")]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Fill in your street")]
        [Display(Name ="Street")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Fill in your number")]
        [Display(Name ="Number")]
        public string Number { get; set; }
        [Required(ErrorMessage = "Fill in your ZIP")]
        [Display(Name ="ZIP")]
        public string Zip { get; set; }
        [Required(ErrorMessage = "Fill in your city")]
        [Display(Name ="City")]
        public string City { get; set; }
        public string? UserId { get; set; }
    }
}
