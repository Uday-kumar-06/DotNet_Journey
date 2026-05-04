namespace RazorPagesApp.Model
{
    public static class ItemRepository
    {
        public static List<Item> Items = new List<Item>
        {
            new Item { Id = 1, Name = "Laptop" },
            new Item { Id = 2, Name = "Mobile" }
        };
    }
}
