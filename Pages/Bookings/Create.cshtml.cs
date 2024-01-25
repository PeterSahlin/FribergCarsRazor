using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FribergCarsRazor;
using FribergCarsRazor.Data;

namespace FribergCarsRazor.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        //private readonly ApplicationDbContext _context;

        //public CreateModel(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly IBooking bookingRepo;
        public CreateModel(IBooking bookingRepo)
        {
            this.bookingRepo = bookingRepo;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bookingRepo.CreateBooking(Booking);

            //_context.Bookings.Add(Booking);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
