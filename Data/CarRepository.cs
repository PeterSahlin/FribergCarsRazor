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
        public void CreateCar(Car car)
        {
            applicationDbContext.Add(car);
            applicationDbContext.SaveChanges();
        }

        //Read
        public IEnumerable<Car> GetAll()
        {
            return applicationDbContext.Cars.OrderBy(c => c.CarName);
        }

        public Car GetById(int id)
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
