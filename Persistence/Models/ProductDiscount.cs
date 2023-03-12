using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Persistence.Models
{
    [Table("Discount")]
    public partial class ProductDiscount : BaseEntity
    {
        public ProductDiscount()
        {
            Products = new HashSet<Product>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0, 100), Display(Name = "Discount Percent")]
        public decimal DiscountPercent { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
