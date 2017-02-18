using System.ComponentModel.DataAnnotations;
namespace playlist.Models
{
    public class RegisterViewModel : BaseEntity
    {
        [Required]
        [MinLength(2, ErrorMessage = "Names must be two characters long!")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "Names must be letters, and have proper capitalization")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Names must be two characters long!")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "Names must be letters, and have proper capitalization")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password and confirmation must match.")]
        public string PasswordConfirmation { get; set; }
        
    }
}



