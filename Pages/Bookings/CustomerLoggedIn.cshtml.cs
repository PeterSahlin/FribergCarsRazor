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
        //private readonly FribergCarsRazor.ApplicationDbContext _context;

        //public CustomerLoggedInModel(FribergCarsRazor.ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        private readonly ICustomer customerRepo;
        

        public CustomerLoggedInModel(ICustomer customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        public Customer Customer { get;set; } = default!;

        public async Task<IActionResult> OnGetAsync(Customer customer)
        {
            var loggedInCustomer = customerRepo.GetById(customer.CustomerId);
            
                /*await _context.Customers.ToListAsync();*/
                if (loggedInCustomer == null)
            {
                return NotFound();
            }
            else
            {
                Customer = customer;
            }
            return Page();



        }
    }
}
