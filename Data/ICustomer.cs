namespace FribergCarsRazor.Data
{
    public interface ICustomer
    {
        //Create
        public void CreateCustomer(Customer customer);
        //Read
        public Customer GetById(int id);
        public IEnumerable<Customer> GetAll();
        //Update
        public void EditCustomer(Customer customer);
        //Delete
        public void DeleteCustomer(Customer customer);

        public Customer GetUserByUserNameAndPassword(string email, string password);
    }
}
