﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergCarsRazor;
using FribergCarsRazor.Data;

namespace FribergCarsRazor.Pages.Admins
{
    public class AdminLoggedInModel : PageModel
    {
        private readonly IAdmin adminRepo;

        public AdminLoggedInModel(IAdmin adminRepo)
        {
            this.adminRepo = adminRepo;
        }

        public Admin Admin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            int adminFromCookie = Convert.ToInt32(Request.Cookies["Admin"]);
            var loggedInAdmin = adminRepo.GetById(adminFromCookie);
           

            /*await _context.Customers.ToListAsync();*/
            if (loggedInAdmin == null)
            {
                return NotFound();
            }
            else
            {
                Admin = loggedInAdmin;
            }
            return Page();
        }
    }
}
