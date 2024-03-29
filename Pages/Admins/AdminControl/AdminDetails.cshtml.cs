﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergCarsRazor.Data;

namespace FribergCarsRazor.Pages.Admins.AdminControl
{
    public class DetailsModel : PageModel
    {
        private readonly IAdmin adminRepo;

        public DetailsModel(IAdmin adminRepo)
        {
            this.adminRepo = adminRepo;
        }

        public Admin Admin { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            var admin = adminRepo.GetById(id);
            if (admin == null)
            {
                return NotFound();
            }
            else
            {
                Admin = admin;
            }
            return Page();
        }
    }
}
