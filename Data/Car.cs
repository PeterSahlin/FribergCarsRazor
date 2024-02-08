using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FribergCarsRazor.Data
{
    public class Car
    {
        [Display(Name = "Car ID")]
        public int CarId { get; set; }

        [Display(Name = "Car name")]
        [Required]
        public string CarName { get; set; }

        [Required]
        public string Seats { get; set; }

        [Display(Name = "Price per day")]
        [Required]
        [RegularExpression(@"^\d{3,}$", ErrorMessage = "Please enter price of at least 3 numbers.")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int Price { get; set; }
       
        public string? Image { get; set; }

    }
}
