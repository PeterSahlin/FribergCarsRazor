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
    public class IndexModel : PageModel
    {
        //private readonly ApplicationDbContext _context;

        //public IndexModel(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly ICustomer customerRepo;

        public IndexModel(ICustomer customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        public IList<Customer> Customer { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Customer = await Task.FromResult(customerRepo.GetAll().ToList());
            /*await _context.Customers.ToListAsync();*/
        }
    }
}
