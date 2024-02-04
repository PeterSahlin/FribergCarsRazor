using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FribergCarsRazor;
using FribergCarsRazor.Data;
using Microsoft.AspNetCore.Http;

namespace FribergCarsRazor.Pages.Admins
{
    public class AdminLoginModel : PageModel
    {
        private readonly IAdmin adminRepo;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AdminLoginModel(IAdmin adminRepo, IHttpContextAccessor httpContextAccessor)
        {
            this.adminRepo = adminRepo;
            this.httpContextAccessor = httpContextAccessor;
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
                else
                {
                    var adminLoggedIn = admin.AdminId.ToString();
                    CookieOptions options = new CookieOptions();
                    options.Expires = DateTimeOffset.UtcNow.AddMinutes(15);
                    httpContextAccessor.HttpContext.Response.Cookies.Append("Admin", adminLoggedIn, options);
                }
            }

            return RedirectToPage("./AdminLoggedIn"/*, admin*/);
        }
    }
}
