using System.ComponentModel.DataAnnotations;
namespace playlist.Models
{
    public class LoginModel : BaseEntity
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }   
    }
}



