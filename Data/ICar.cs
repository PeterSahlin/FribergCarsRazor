﻿namespace FribergCarsRazor.Data
{
    public interface ICar
    {
        //Create
        public Task CreateCar(Car car);
        //Read
        Car GetById(int id);
        IEnumerable<Car> GetAll();
        //Update
        public void EditCar(Car car);
        //Delete
        public void DeleteCar(Car car);
    }
}
