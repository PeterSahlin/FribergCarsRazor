using System.ComponentModel.DataAnnotations;

namespace FribergCarsRazor.Data
{
    public class Booking
    {
        [Display(Name = "Booking ID")]
        public int BookingId { get; set; }

        [Display(Name = "Pickup date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }


        [Display(Name = "Return date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public Customer Customer { get; set; }
        public Car Car { get; set; }   
    }
}
