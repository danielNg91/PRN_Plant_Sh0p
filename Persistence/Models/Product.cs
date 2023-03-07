﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Persistence.Models
{
    [Table("Product")]
    public partial class Product : BaseEntity
    {
        public Product()
        {
            CartItems = new HashSet<CartItem>();
            OrderItems = new HashSet<OrderItem>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Guid? DiscountId { get; set; }
        public virtual ProductCategory Category { get; set; }
        public virtual ProductDiscount Discount { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
