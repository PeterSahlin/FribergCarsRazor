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
    public class DeleteModel : PageModel
    {
        
        private readonly IBooking bookingRepo;
        public DeleteModel(IBooking bookingRepo)
        {
            this.bookingRepo = bookingRepo;
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = bookingRepo.GetById(id);
                /*await _context.Bookings.FirstOrDefaultAsync(m => m.BookingId == id);*/

            if (booking == null)
            {
                return NotFound();
            }
            else
            {
                Booking = booking;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = bookingRepo.GetById(id);
            /*await _context.Bookings.FindAsync(id);*/
            if (booking != null)
            {
                Booking = booking;
                bookingRepo.DeleteBooking(booking);
                
                //await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
