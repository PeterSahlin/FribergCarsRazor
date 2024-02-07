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
    public class CustomerLoggedInModel : PageModel
    {
       
        private readonly ICustomer customerRepo;

        public CustomerLoggedInModel(ICustomer customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        public Customer Customer { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            int userFromCookie= Convert.ToInt32(Request.Cookies["User"]);
            var loggedInCustomer = customerRepo.GetById(userFromCookie);

            if (loggedInCustomer == null)
            {
                return NotFound();
            }
            else
            {
                Customer = loggedInCustomer;
            }
            return Page();
        }

        public async Task<IActionResult> OnGetAfterBooking(int id)
        {
            var loggedInCustomer = customerRepo.GetById(id);

            if (loggedInCustomer == null)
            {
                return NotFound();
            }
            else
            {
                Customer = loggedInCustomer;
            }
            return Page();
        }
    }
}
