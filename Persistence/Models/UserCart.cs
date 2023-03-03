using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Persistence.Models
{
    [Table("Cart")]
    public partial class UserCart : BaseEntity
    {
        public UserCart()
        {
            CartItems = new HashSet<CartItem>();
        }

        public int UserId { get; set; }
        public decimal Total { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
