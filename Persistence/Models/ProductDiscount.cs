﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Persistence.Models
{
    public partial class ProductDiscount : BaseEntity
    {
        public ProductDiscount()
        {
            Products = new HashSet<Product>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal DiscountPercent { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}