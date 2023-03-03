using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Persistence.Models
{
    [Table("CartItems")]
    public partial class CartItem : BaseEntity
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual UserCart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}
