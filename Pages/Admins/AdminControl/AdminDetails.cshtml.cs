using System;
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
        //private readonly FribergCarsRazor.ApplicationDbContext _context;

        //public DetailsModel(FribergCarsRazor.ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly IAdmin adminRepo;

        public DetailsModel(IAdmin adminRepo)
        {
            this.adminRepo = adminRepo;
        }

        public Admin Admin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var admin = await _context.Admins.FirstOrDefaultAsync(m => m.AdminId == id);
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
