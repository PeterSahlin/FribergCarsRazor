using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FribergCarsRazor.Data
{
    public class Customer
    {
        [Display(Name = "Customer ID")]
        public int CustomerId { get; set; }

        [Display(Name = "First name")]
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Surname")]
        [Required]
        public string LastName { get; set; } = string.Empty;

        [EmailAddress]
        [Required]
        public required string Email { get; set; }

        [PasswordPropertyText]
        [Required (ErrorMessage = "Password needs to be between 4 and 30 characters.")]
        [Length( 4, 30)]
       
        public required string Password { get; set; }


    
    }
}
