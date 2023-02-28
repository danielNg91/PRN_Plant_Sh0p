using System;
using System.Collections.Generic;

#nullable disable

namespace Persistence.Models
{
    public partial class Product : BaseEntity
    {
        public Product()
        {
            CartItems = new HashSet<CartItem>();
            OrderItems = new HashSet<OrderItem>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int? DiscountId { get; set; }
        public virtual ProductCategory Category { get; set; }
        public virtual ProductDiscount Discount { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
