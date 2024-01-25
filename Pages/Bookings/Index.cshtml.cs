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
    public class IndexModel : PageModel
    {

        //private readonly ApplicationDbContext _context;

        //public IndexModel(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly IBooking bookingRepo;
        public IndexModel(IBooking bookingRepo)
        {
            this.bookingRepo = bookingRepo;
        }

        public IList<Booking> Booking { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Booking = await Task.FromResult(bookingRepo.GetAll().ToList());
        }
    }
}
