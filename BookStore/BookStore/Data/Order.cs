using System.ComponentModel.DataAnnotations;

namespace BookStore.Data
{
    public class Order
    {
        /// <summary>
        /// Unique ID of an order
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// First name of the user who buy the book(s)
        /// </summary>
        [Required(ErrorMessage ="Fill in your first name")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        /// <summary>
        /// Last name of the user who buy the book(s)
        /// </summary>
        [Required(ErrorMessage = "Fill in your last name")]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        /// <summary>
        /// Street of the user who buy the book(s)
        /// </summary>
        [Required(ErrorMessage = "Fill in your street")]
        [Display(Name ="Street")]
        public string Street { get; set; }
        /// <summary>
        /// Number of the house from the user who buy the book(s)
        /// </summary>
        [Required(ErrorMessage = "Fill in your number")]
        [Display(Name ="Number")]
        public int Number { get; set; }
        /// <summary>
        /// The ZIP-code of the user who buy the book(s)
        /// </summary>
        [Required(ErrorMessage = "Fill in your ZIP")]
        [Display(Name ="ZIP")]
        public int Zip { get; set; }
        /// <summary>
        /// The city of user who buy the book(s)
        /// </summary>
        [Required(ErrorMessage = "Fill in your city")]
        [Display(Name ="City")]
        public string City { get; set; }
        /// <summary>
        /// Unique ID of the user who buy the book(s)
        /// </summary>
        public string? UserId { get; set; }
    }
}
