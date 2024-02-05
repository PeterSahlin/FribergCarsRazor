using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FribergCarsRazor.Data;

namespace FribergCarsRazor.Pages.Admins.BookingControl
{
    public class EditModel : PageModel
    {
        //private readonly ApplicationDbContext _context;

        //public EditModel(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly IBooking bookingRepo;
        private readonly ICar carRepo;
        private readonly ICustomer customerRepo;

        public EditModel(IBooking bookingRepo, ICar carRepo, ICustomer customerRepo)
        {
            this.bookingRepo = bookingRepo;
            this.carRepo = carRepo;
            this.customerRepo = customerRepo;
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        public IEnumerable<Car> CarList { get; set; }           //Den här har jag lagt till nu

        public async Task<IActionResult> OnGetAsync(int id)
        {
            CarList = carRepo.GetAll();                     //det här har jag lagt till nu
            
            if (id == null)
            {
                return NotFound();
            }

            var booking = bookingRepo.GetById(id);
            //Booking.Customer = customerRepo.GetById(booking.Customer.CustomerId);
            
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
          

            return RedirectToPage("./CustomerBookingIndex");
        }

    }
}
