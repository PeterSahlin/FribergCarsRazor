using System;
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
    public class DeleteModel : PageModel
    {
        //private readonly FribergCarsRazor.ApplicationDbContext _context;

        //public DeleteModel(FribergCarsRazor.ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly IAdmin adminRepo;

        public DeleteModel(IAdmin adminRepo)
        {
            this.adminRepo = adminRepo;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var admin = await _context.Admins.FindAsync(id);
            var admin = adminRepo.GetById(id);

            if (admin != null)
            {
                Admin = admin;
                //_context.Admins.Remove(Admin);
                //await _context.SaveChangesAsync();
                adminRepo.DeleteAdmin(admin);
            }

            return RedirectToPage("./Index");
        }
    }
}
