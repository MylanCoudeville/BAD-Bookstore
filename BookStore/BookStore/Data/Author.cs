using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Data
{
    [Table("Autors")]
    public class Author
    {
        /// <summary>
        /// Unique value of an author
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// First name of an author
        /// </summary>
        [Required(ErrorMessage = "Please fill in the first name.")]
        [MaxLength(255)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        /// <summary>
        /// Last name of an author
        /// </summary>
        [Required(ErrorMessage = "Please fill in the last name.")]
        [MaxLength(255)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        /// <summary>
        /// Birthday of an author
        /// </summary>
        [Required(ErrorMessage = "Please fill in the birth date.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Collection of books of an author
        /// </summary>
        public ICollection<Book>? Books { get; set;}
    }
}
