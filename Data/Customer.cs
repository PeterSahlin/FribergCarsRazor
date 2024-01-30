namespace FribergCarsRazor.Data
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;


        public required string Email { get; set; }

        public required string Password { get; set; }


        //public ICollection<Booking> CustomerBookings { get; set; }
    }
}
