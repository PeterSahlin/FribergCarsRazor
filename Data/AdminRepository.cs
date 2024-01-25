namespace FribergCarsRazor.Data
{
    public class AdminRepository:IAdmin
    {
        private readonly ApplicationDbContext applicationDbContext;

        public AdminRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }


        //CRUD

        //Create
        public void CreateAdmin(Admin admin)
        {
            applicationDbContext.Add(admin);
            applicationDbContext.SaveChanges();
        }

        //Read
        public IEnumerable<Admin> GetAll()
        {
            return applicationDbContext.Admins.OrderBy(a => a.LastName);
        }

        public Admin GetById(int id)
        {
            return applicationDbContext.Admins.FirstOrDefault(a => a.AdminId == id);
        }

        //Update
        public void EditAdmin(Admin admin)
        {
            applicationDbContext.Update(admin);
            applicationDbContext.SaveChanges();
        }
        //Delete
        public void DeleteAdmin(Admin admin)
        {
            applicationDbContext.Remove(admin);
            applicationDbContext.SaveChanges();
        }
    }
}
