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
    public class IndexModel : PageModel
    {
        private readonly IBooking bookingRepo;
        public IndexModel(IBooking bookingRepo)
        {
            this.bookingRepo = bookingRepo;
        }

        [BindProperty]
        public IList<Booking> Booking { get;set; } = default!;                  //Ienumerable?

        public async Task OnGetAsync()
        {
            int userFromCookie = Convert.ToInt32(Request.Cookies["User"]);

            Booking = bookingRepo.GetCustomerBookingsByCustomerId(userFromCookie).ToList();
            //Booking = await Task.FromResult(bookingRepo.GetAll().ToList());
        }
    }
}
