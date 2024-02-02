using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FribergCarsRazor;
using FribergCarsRazor.Data;

namespace FribergCarsRazor.Pages.Admins
{
    public class AdminLoginModel : PageModel
    {
        private readonly IAdmin adminRepo;

        public AdminLoginModel(IAdmin adminRepo)
        {
            this.adminRepo = adminRepo;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Admin Admin { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var admin = adminRepo.GetAdminByEmailNameAndPassword(Admin.Email, Admin.Password);

            if (!ModelState.IsValid)
            {
                if (admin == null)
                {
                    return Page();

                }
            }

            return RedirectToPage("./AdminLoggedIn", admin);
        }
    }
}
