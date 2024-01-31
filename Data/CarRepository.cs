namespace FribergCarsRazor.Data
{
    public class CarRepository :ICar
    {
        private readonly ApplicationDbContext applicationDbContext;

        public CarRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        //CRUD

        //Create
        public Task CreateCar(Car car)
        {
            applicationDbContext.Add(car);
            return applicationDbContext.SaveChangesAsync();
            
        }

        //Read
        public IEnumerable<Car> GetAll()
        {
            return applicationDbContext.Cars.OrderBy(c => c.CarName);
        }

        public Car GetById(int id)                                                                      //return Task<Car>, await. FirsorDef asyncversion. 
        {
            return applicationDbContext.Cars.FirstOrDefault(c => c.CarId == id);
        }

        //Update
        public void EditCar(Car car)
        {
            applicationDbContext.Update(car);
            applicationDbContext.SaveChanges();
        }

        //Delete
        public void DeleteCar(Car car)
        {
            applicationDbContext.Remove(car);
            applicationDbContext.SaveChanges();
        }


    }
}
