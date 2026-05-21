namespace FoodDeliveryAPI.Models
{
    public class DeliveryTracking
    {
        public int DeliveryTrackingId { get; set; }
        public string DeliveryStatus { get; set; }
        public string CurrentLocation { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
