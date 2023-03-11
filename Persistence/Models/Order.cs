using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Persistence.Models
{
    [Table("Order")]
    public partial class Order : BaseEntity
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public Guid UserId { get; set; }
        public Guid CartId { get; set; }
        public decimal Total { get; set; }
        public bool PaymentStatus { get; set; } = false;
        public string DeliveryStatus { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual UserCart UserCart { get; set; }
    }
}
