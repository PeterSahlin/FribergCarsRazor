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
    public class ConfirmBookingModel : PageModel
    {
        //private readonly FribergCarsRazor.ApplicationDbContext _context;
        private readonly ICar carRepo;
        //private readonly ICar bookingRepo;

        //public ConfirmBookingModel(FribergCarsRazor.ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        public ConfirmBookingModel(ICar carRepo)
        {
            this.carRepo = carRepo;
        }

        public Booking Booking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = carRepo.GetById(id);
                Booking.Car = car;


            /*await _context.Bookings.FirstOrDefaultAsync(m => m.BookingId == id);*/
            if (car == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }

        }


        public async Task<IActionResult> OnPostAsync(Booking booking)
        {
            var car = carRepo.GetById(booking.Car.CarId);
            booking.Car = car;

            if (!ModelState.IsValid)
            {
                return RedirectToPage("./BookingConfirmed", new { bookingData = booking });
            }
            else
            {
                return Page();
            }
        }
    }
}
