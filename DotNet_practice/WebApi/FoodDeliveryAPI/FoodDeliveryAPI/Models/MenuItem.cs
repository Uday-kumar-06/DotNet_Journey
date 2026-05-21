namespace FoodDeliveryAPI.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
