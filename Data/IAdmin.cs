namespace FribergCarsRazor.Data
{
    public interface IAdmin
    {
        //Create
        public void CreateAdmin(Admin admin);
        //Read
        Admin GetById(int id);
        IEnumerable<Admin> GetAll();
        //Update
        public void EditAdmin(Admin admin);
        //Delete
        public void DeleteAdmin(Admin admin);
    }
}
