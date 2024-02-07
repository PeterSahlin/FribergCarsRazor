using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergCarsRazor.Data;

namespace FribergCarsRazor.Pages.Admins.CarControl
{
    public class DetailsModel : PageModel
    {
        private readonly ICar carRepo;

        public DetailsModel(ICar carRepo)
        {
            this.carRepo = carRepo;
        }

        public Car Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = carRepo.GetById(id);
            /*await _context.Cars.FirstOrDefaultAsync(m => m.CarId == id);*/
            if (car == null)
            {
                return NotFound();
            }
            else
            {
                Car = car;
            }
            return Page();
        }
    }
}
