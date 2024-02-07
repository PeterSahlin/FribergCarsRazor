using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergCarsRazor.Data;

namespace FribergCarsRazor.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly ICar carRepo;

        public IndexModel(ICar carRepo)
        {
            this.carRepo = carRepo;
        }

        public IList<Car> Car { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Car = await Task.FromResult(carRepo.GetAll().ToList());
            /*await _context.Cars.ToListAsync();*/
        }
    }
}
