using FribergCarsRazor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FribergCarsRazor.Pages.Bookings
{
    public class LoginModel : PageModel
    {

        //private readonly ILogger<PrivacyModel> _logger;

        //public PrivacyModel(ILogger<PrivacyModel> logger)
        //{
        //    _logger = logger;
        //}


        private readonly ICustomer customerRepo;
        private Customer loggedInCustomer;

        public LoginModel(ICustomer customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync()
        {
            var customer = customerRepo.GetUserByUserNameAndPassword(Customer.Email, Customer.Password);

            if (ModelState.IsValid)
            {
                if (customer == null)
                {
                    return Page();
                }
                else
                {
                    loggedInCustomer = customer;
                    return RedirectToPage("/Admins/Index", loggedInCustomer); //boka bil-sidan, 
                }

            }
            return RedirectToPage("./Index");

            //var customer = customerRep.CheckCustomerUser(Customer.UserName, Customer.Password);
            //if (customer == null)
            //{
            //    return Page();
            //}


            //return RedirectToPage("./LoginIndex", customer);

        }
    }

}
