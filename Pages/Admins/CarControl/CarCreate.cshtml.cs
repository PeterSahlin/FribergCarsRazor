using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FribergCarsRazor.Data;

namespace FribergCarsRazor.Pages.Admins.CarControl
{
    public class CreateModel : PageModel
    {
        //private readonly ApplicationDbContext _context;

        //public CreateModel(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly ICar carRepo;

        public CreateModel(ICar carRepo)
        {
            this.carRepo = carRepo;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            carRepo.CreateCar(Car);
            //_context.Cars.Add(Car);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
