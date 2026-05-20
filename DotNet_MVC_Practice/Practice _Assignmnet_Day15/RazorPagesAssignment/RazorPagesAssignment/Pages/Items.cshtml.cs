using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesAssignment.Data;
using RazorPagesAssignment.Models;

namespace RazorPagesAssignment.Pages
{
    public class ItemsModel : PageModel
    {
        public List<Item> ItemList { get; set; }

        public void OnGet()
        {
            ItemList = ItemRepository.Items;
        }
    }
}
