using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Model;

namespace RazorPagesApp.Pages
{
    public class AddItemModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; }

        public IActionResult OnPost()
        {
            var newItem = new Item
            {
                Id = ItemRepository.Items.Count + 1,
                Name = Name
            };

            ItemRepository.Items.Add(newItem);

            return RedirectToPage("Index");
        }
    }
}
