using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesAssignment.Data;
using RazorPagesAssignment.Models;

namespace RazorPagesAssignment.Pages
{
    public class AddItemModel : PageModel
    {
        [BindProperty]
        public Item NewItem { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            NewItem.Id = ItemRepository.Items.Count + 1;

            ItemRepository.Items.Add(NewItem);

            return RedirectToPage("/Items");
        }
    }
}