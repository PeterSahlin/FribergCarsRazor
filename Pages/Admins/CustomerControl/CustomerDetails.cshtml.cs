using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergCarsRazor.Data;

namespace FribergCarsRazor.Pages.Admins.CustomerControl
{
    public class DetailsModel : PageModel
    {
        //private readonly ApplicationDbContext _context;

        //public DetailsModel(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly ICustomer customerRepo;

        public DetailsModel(ICustomer customerRepo)
        {
            this.customerRepo = customerRepo;
        }
        public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var customer = await _context.Customers.FirstOrDefaultAsync(m => m.CustomerId == id);
            var customer = customerRepo.GetById(id);
            if (customer == null)
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
