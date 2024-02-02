using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FribergCarsRazor.Data;

namespace FribergCarsRazor.Pages.Admins.CustomerControl
{
    public class EditModel : PageModel
    {

        //private readonly ApplicationDbContext _context;

        //public EditModel(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly ICustomer customerRepo;
        public EditModel(ICustomer customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        [BindProperty]
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
            Customer = customer;
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
            customerRepo.EditCustomer(Customer);
            //_context.Attach(Customer).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!CustomerExists(Customer.CustomerId))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return RedirectToPage("./CustomerIndex");
        }

        //private bool CustomerExists(int id)
        //{
        //    return _context.Customers.Any(e => e.CustomerId == id);
        //}
    }
}
