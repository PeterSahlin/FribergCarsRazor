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
        private readonly ICar carRepo;
        private readonly IBooking bookingRepo;

        public CreateModel(ICustomer customerRepo, ICar carRepo, IBooking bookingRepo)
        {
            this.customerRepo = customerRepo;
            this.carRepo = carRepo;
            this.bookingRepo = bookingRepo;
        }

        public Booking Booking { get; set; } = new Booking();
        public Customer Customer { get; set; } = default!;

        public IEnumerable<Car> CarList { get; set; }


        public IActionResult OnGet(/*int id*/)
        {
            int userFromCookie = Convert.ToInt32(Request.Cookies["User"]);
            var loggedInCustomer = customerRepo.GetById(userFromCookie);
            //var loggedInCustomer = customerRepo.GetById(id);

            Booking.Customer = loggedInCustomer;

            CarList = carRepo.GetAll();


            return Page();

            //}
        }

        //[BindProperty]
        //public Booking Booking { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(Booking booking)                     
        {
            int userFromCookie = Convert.ToInt32(Request.Cookies["User"]);
            

            var customer = customerRepo.GetById(userFromCookie);          
            booking.Customer = customer;

            var selectedCar = carRepo.GetById(booking.Car.CarId);
                booking.Car = selectedCar;

            if (!ModelState.IsValid)
            {
                bookingRepo.CreateBooking(booking);
                //return RedirectToPage("./CustomerLoggedIn", customer);
                return RedirectToPage("./BookingConfirmed"/*, customer*/);

            }
            else
            {
                return Page();
            }
           

        }
    }
}
