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
    public class LogintestModel : PageModel
    {
        //private readonly FribergCarsRazor.ApplicationDbContext _context;

        //public LogintestModel(FribergCarsRazor.ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly ICustomer customerRepo;
        private Customer loggedInCustomer;

        public LogintestModel(ICustomer customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var customer = customerRepo.GetUserByUserNameAndPassword(Customer.Email, Customer.Password);

            if (ModelState.IsValid)
            {
                if (customer == null)
                {
                    return Page();
                }
                else
                {
                    loggedInCustomer = customer;
                    //return RedirectToPage("/Admins/Index", loggedInCustomer); //boka bil-sidan, 
                }

            }
            return RedirectToPage("./CustomerLoggedIn", customer);
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //_context.Customers.Add(Customer);
            //await _context.SaveChangesAsync();

            //return RedirectToPage("./Index");
        }
    }
}
