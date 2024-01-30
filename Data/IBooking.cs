﻿namespace FribergCarsRazor.Data
{
    public interface IBooking
    {
        //Create
        public void CreateBooking(Booking booking);
        //Read
        Booking GetById(int id);
        IEnumerable<Booking> GetAll();
        //Update
        public void EditBooking(Booking booking);
        //Delete
        public void DeleteBooking(Booking booking);
    }
}