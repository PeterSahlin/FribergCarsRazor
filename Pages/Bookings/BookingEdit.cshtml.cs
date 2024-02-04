using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FribergCarsRazor;
using FribergCarsRazor.Data;

namespace FribergCarsRazor.Pages.Bookings
{
    public class EditModel : PageModel
    {
        //private readonly ApplicationDbContext _context;

        //public EditModel(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly IBooking bookingRepo;
        public EditModel(IBooking bookingRepo)
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
            Booking = booking;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bookingRepo.EditBooking(Booking);
            //_context.Attach(Booking).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!BookingExists(Booking.BookingId))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return RedirectToPage("./Index");
        }

        //private bool BookingExists(int id)
        //{
        //    return _context.Bookings.Any(e => e.BookingId == id);
        //}
    }
}
