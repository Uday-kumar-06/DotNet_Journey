using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdvancedRazorPagesApp.Models;

namespace AdvancedRazorPagesApp.Pages.Products
{
    public class DetailsModel : PageModel
    {
        public Product Product { get; set; }

        public IActionResult OnGet(int id)
        {
            Product = IndexModel.ProductList
                        .FirstOrDefault(p => p.ProductID == id);

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}