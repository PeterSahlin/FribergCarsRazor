﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FribergCarsRazor.Data;

namespace FribergCarsRazor.Pages.Admins.CustomerControl
{
    public class CreateModel : PageModel
    {
        private readonly ICustomer customerRepo;
        public CreateModel(ICustomer customerRepo)
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            customerRepo.CreateCustomer(Customer);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./CustomerIndex");
        }
    }
}
