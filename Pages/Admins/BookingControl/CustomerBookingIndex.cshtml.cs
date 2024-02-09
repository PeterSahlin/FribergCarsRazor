using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergCarsRazor;
using FribergCarsRazor.Data;

namespace FribergCarsRazor.Pages.Admins.BookingControl
{
    public class IndexModel : PageModel
    {

        private readonly IBooking bookingRepo;
        public IndexModel(IBooking bookingRepo)
        {
            this.bookingRepo = bookingRepo;
        }

        [BindProperty]
        public IList<Booking> Booking { get;set; } = default!;

        public async Task OnGetAsync()
        {
            

            Booking = bookingRepo.GetCustomerBookingsList().ToList();
            


        }
    }
}
