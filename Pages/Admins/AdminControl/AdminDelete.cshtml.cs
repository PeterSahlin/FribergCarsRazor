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
    public class DeleteModel : PageModel
    {
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

            var admin = adminRepo.GetById(id);

            if (admin != null)
            {
                Admin = admin;
                adminRepo.DeleteAdmin(admin);
            }

            return RedirectToPage("./AdminIndex");
        }
    }
}
