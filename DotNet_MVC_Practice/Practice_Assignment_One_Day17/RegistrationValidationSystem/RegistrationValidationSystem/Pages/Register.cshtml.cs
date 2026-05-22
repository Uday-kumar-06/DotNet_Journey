using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RegistrationValidationSystem.Models;

namespace RegistrationValidationSystem.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public UserRegistration Registration { get; set; }

        public string SuccessMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            SuccessMessage = "Registration Successful!";

            return Page();
        }
    }
}