using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Model;

namespace RazorPagesApp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Item> ItemList { get; set; }

        public void OnGet()
        {
            ItemList = ItemRepository.Items;

        }
    }
}