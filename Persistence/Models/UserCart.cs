using System;
using System.Collections.Generic;

#nullable disable

namespace Persistence.Models
{
    public partial class UserCart : BaseEntity
    {
        public UserCart()
        {
            CartItems = new HashSet<CartItem>();
        }

        public int UserId { get; set; }
        public decimal Total { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
