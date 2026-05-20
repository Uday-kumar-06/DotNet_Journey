using RazorPagesAssignment.Models;

namespace RazorPagesAssignment.Data
{
    public class ItemRepository
    {
        public static List<Item> Items = new List<Item>()
        {
            new Item { Id = 1, Name = "Laptop", Price = 50000 },
            new Item { Id = 2, Name = "Mouse", Price = 500 }
        };
    }
}
