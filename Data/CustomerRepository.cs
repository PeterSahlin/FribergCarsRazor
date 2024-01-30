namespace FribergCarsRazor.Data
{
    public class CustomerRepository:ICustomer
    {
        private readonly ApplicationDbContext applicationDbContext;

        public CustomerRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        //CRUD

        //Create
        public void CreateCustomer(Customer customer)
        {
            applicationDbContext.Add(customer);
            applicationDbContext.SaveChanges();
        }

        //Read
        public IEnumerable<Customer> GetAll()
        {
            return applicationDbContext.Customers.OrderBy(c => c.LastName);
        }

        public Customer GetById(int id)
        {
            return applicationDbContext.Customers.FirstOrDefault(c => c.CustomerId == id);
        }

        //Update
        public void EditCustomer(Customer customer)
        {
            applicationDbContext.Update(customer);
            applicationDbContext.SaveChanges();
        }

        //Delete
        public void DeleteCustomer(Customer customer)
        {
            applicationDbContext.Remove(customer);
            applicationDbContext.SaveChanges();
        }

        //Find user in database from login entry
        public Customer GetUserByUserNameAndPassword(string email, string password)
        {
            var customer = applicationDbContext.Customers.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
            return customer;



        }
    }
}
