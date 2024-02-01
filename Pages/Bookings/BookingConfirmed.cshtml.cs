using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergCarsRazor;
using FribergCarsRazor.Data;

namespace FribergCarsRazor.Pages.Bookings
{
    public class BookingConfirmedModel : PageModel
    {
        
        private readonly IBooking bookingRepo;

        public BookingConfirmedModel(IBooking bookingRepo)
        {
           
            this.bookingRepo = bookingRepo;
        }

        public Booking Booking { get;set; } = default!;

        public async Task OnGetAsync(Customer customer)
        {
            

            Booking =bookingRepo.GetBookingByCustomerId(customer.CustomerId);


            
        }
    }
}
