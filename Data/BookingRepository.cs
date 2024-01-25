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
            return applicationDbContext.Bookings.FirstOrDefault(b => b.BookingId == id);
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

    }
}
