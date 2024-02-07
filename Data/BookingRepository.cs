using Microsoft.EntityFrameworkCore;

namespace FribergCarsRazor.Data
{
    public class BookingRepository:IBooking
    {
        private readonly ApplicationDbContext applicationDbContext;

        public BookingRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        //CRUD

        //Create
        public void CreateBooking(Booking booking)
        {
            applicationDbContext.Add(booking);
            applicationDbContext.SaveChanges();
        }

        //Read
        public IEnumerable<Booking> GetAll()
        {
            return applicationDbContext.Bookings.OrderBy(b => b.BookingId);
        }

        public Booking GetById(int id)
        {
            return applicationDbContext.Bookings
                .Include(b => b.Customer)
                .FirstOrDefault(b => b.BookingId == id);
        }

        //Edit
        public void EditBooking(Booking booking)
        {
            applicationDbContext.Update(booking);
            applicationDbContext.SaveChanges();
        }

        //Delete
        public void DeleteBooking(Booking booking)
        {
            applicationDbContext.Remove(booking);
            applicationDbContext.SaveChanges();
        }

        public Booking GetBookingByCustomerId(int customerId)
        {
            return applicationDbContext.Bookings
                .Include(b=>b.Customer)
                .Include(b=>b.Car)
                .OrderByDescending(b => b.BookingId)
                .FirstOrDefault(b => b.Customer.CustomerId == customerId);
        }

        public IEnumerable<Booking> GetCustomerBookingsList()
        {
           
                return applicationDbContext.Bookings
                    .Include(b => b.Customer)
                    .Include(b => b.Car)
                    .OrderBy(b=>b.Customer.CustomerId);
            
        }

        public IEnumerable<Booking> GetCustomerBookingsByCustomerId(int customerId)
        {
            return applicationDbContext.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Car)
                .Where(b => b.Customer.CustomerId == customerId);
        }

    }
}
