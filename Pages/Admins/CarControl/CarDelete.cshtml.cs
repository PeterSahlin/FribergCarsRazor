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
    public class DeleteModel : PageModel
    {
        //private readonly ApplicationDbContext _context;

        //public DeleteModel(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly ICar carRepo;

        public DeleteModel(ICar carRepo)
        {
            this.carRepo = carRepo;
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var car = await _context.Cars.FirstOrDefaultAsync(m => m.CarId == id);

            var car = carRepo.GetById(id);

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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var car = await _context.Cars.FindAsync(id);
            var car = carRepo.GetById(id);

            if (car != null)
            {
                Car = car;
                carRepo.DeleteCar(car);
                //_context.Cars.Remove(Car);
                //await _context.SaveChangesAsync();
            }

            return RedirectToPage("./CarIndex");
        }
    }
}
