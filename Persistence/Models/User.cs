using System;
using System.Collections.Generic;

#nullable disable

namespace Persistence.Models
{
    public partial class User : BaseEntity
    {
        public User()
        {
            Orders = new HashSet<Order>();
            UserCarts = new HashSet<UserCart>();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int RoleId { get; set; }
        public string Address { get; set; }

        public virtual UserRole Role { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<UserCart> UserCarts { get; set; }
    }
}
