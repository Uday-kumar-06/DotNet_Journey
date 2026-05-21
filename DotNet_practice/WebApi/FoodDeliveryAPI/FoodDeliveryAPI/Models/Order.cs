using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public Payment Payment { get; set; }

        public DeliveryTracking DeliveryTracking { get; set; }
    }
}
