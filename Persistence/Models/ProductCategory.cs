using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Persistence.Models
{
    public partial class ProductCategory : BaseEntity
    {
        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
