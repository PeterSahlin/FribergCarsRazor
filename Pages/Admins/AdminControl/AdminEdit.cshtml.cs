using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FribergCarsRazor.Data;

namespace FribergCarsRazor.Pages.Admins.AdminControl
{
    public class EditModel : PageModel
    {
        //private readonly FribergCarsRazor.ApplicationDbContext _context;

        //public EditModel(FribergCarsRazor.ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly IAdmin adminRepo;

        public EditModel(IAdmin adminRepo)
        {
            this.adminRepo = adminRepo;
        }

        [BindProperty]
        public Admin Admin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            int adminFromCookie = Convert.ToInt32(Request.Cookies["Admin"]);
            

            if (adminFromCookie == null)
            {
                return NotFound();
            }

            //var admin =  await _context.Admins.FirstOrDefaultAsync(m => m.AdminId == id);
            var admin = adminRepo.GetById(adminFromCookie);
            if (admin == null)
            {
                return NotFound();
            }
            Admin = admin;
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

            adminRepo.EditAdmin(Admin);
            

            return RedirectToPage("./AdminIndex");
        }

       
    }
}
