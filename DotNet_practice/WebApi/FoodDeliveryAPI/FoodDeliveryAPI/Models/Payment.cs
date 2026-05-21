using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryAPI.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

    }
}
