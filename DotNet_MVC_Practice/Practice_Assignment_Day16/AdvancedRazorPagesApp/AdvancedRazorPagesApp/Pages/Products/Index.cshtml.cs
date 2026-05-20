using AdvancedRazorPagesApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdvancedRazorPagesApp.Pages.Products
{
    public class IndexModel : PageModel
    {
        // Static list for demo purpose
        public static List<Product> ProductList = new List<Product>();

        // Model Binding
        [BindProperty]
        public Product NewProduct { get; set; }

        public List<Product> Products => ProductList;

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // Assign Product ID
            NewProduct.ProductID = ProductList.Count + 1;

            ProductList.Add(NewProduct);

            return RedirectToPage();
        }
    }
}
