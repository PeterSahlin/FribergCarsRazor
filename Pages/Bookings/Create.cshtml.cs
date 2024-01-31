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

       
        private readonly ICustomer customerRepo;

        public CreateModel(ICustomer customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        public Booking Booking { get; set; } = new Booking();
        public Customer Customer { get; set; } = default!;

        public IActionResult OnGet(int id)
        {

            var loggedInCustomer = customerRepo.GetById(id);
            //if (false)
            //{
            //  return  RedirectToPage("Login");
            //}
            //else
            //{
            Booking.Customer = loggedInCustomer;
            return Page();

            //}
        }

        //[BindProperty]
        //public Booking Booking { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(Booking booking)
        {
            var customer = customerRepo.GetById(booking.Customer.CustomerId);
            booking.Customer = customer;

            if (!ModelState.IsValid)
            {
                return RedirectToPage("./PickCar", new { bookingData = booking });
            }
            else
            {
                return Page();
            }
            //customerRepo.CreateBooking(booking);

            //_context.Bookings.Add(Booking);
            //await _context.SaveChangesAsync();

        }
    }
}
