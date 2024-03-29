using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FribergCarsRazor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnGetLogOut()
        {

            if (Request.Cookies["User"] != null)
            {
                Response.Cookies.Delete("User");
                return RedirectToPage("/LoggedOut");
                
            }
            else if (Request.Cookies["Admin"] != null)
            {
                Response.Cookies.Delete("Admin");
               return RedirectToPage("/LoggedOut");
                
            }
            return Page();
        }




    }
}
