using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FribergCarsRazor.Data;

namespace FribergCarsRazor.Pages.Admins.AdminControl
{
    public class CreateModel : PageModel
    {
        //private readonly FribergCarsRazor.ApplicationDbContext _context;

        //public CreateModel(FribergCarsRazor.ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly IAdmin adminRepo;

        public CreateModel(IAdmin adminRepo)
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            adminRepo.CreateAdmin(Admin);
            //_context.Admins.Add(Admin);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
