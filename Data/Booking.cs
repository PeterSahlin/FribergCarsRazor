namespace FribergCarsRazor.Data
{
    public class Booking
    {
        public int BookingId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Customer Customer { get; set; }
        public Car Car { get; set; }
    }
}
