using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FribergCarsRazor;
using FribergCarsRazor.Data;

namespace FribergCarsRazor.Pages.Bookings
{
    public class PickCarModel : PageModel
    {
        private readonly ICar carRepo;

        //private readonly FribergCarsRazor.ApplicationDbContext _context;

        //public PickCarModel(FribergCarsRazor.ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        public PickCarModel(ICar carRepo)
        {
            this.carRepo = carRepo;
        }

        public IList<Car> Car { get;set; } = default!;

        public async Task OnGetAsync(Booking booking)
        {
            Car = await Task.FromResult(carRepo.GetAll().ToList());
        }


    }
}
