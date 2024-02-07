using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FribergCarsRazor.Data
{
    public class Admin
    {
        [Display(Name = "Admin ID")]
        public int AdminId { get; set; }

        [Display(Name = "First name")]
        [Required]
        public string FirstName { get; set; }
        
        [Display(Name = "Surname")]
        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [PasswordPropertyText]
        [Required(ErrorMessage = "Password needs to be between 4 and 30 characters.")]
        [Length(4, 30)]
        public string Password { get; set; }
    }
}
