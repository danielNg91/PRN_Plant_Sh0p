using System;
using System.Collections.Generic;

#nullable disable

namespace Persistence.Models
{
    public partial class Order : BaseEntity
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int UserId { get; set; }
        public decimal Total { get; set; }
        public bool PaymentStatus { get; set; }
        public string DeliveryStatus { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
