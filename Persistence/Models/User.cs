using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Persistence.Models
{
    [Table("User")]
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
        public string Address { get; set; }
        public bool IsAdmin { get; set; } = false;

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<UserCart> UserCarts { get; set; }
    }
}
