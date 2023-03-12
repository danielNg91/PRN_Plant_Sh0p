using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Fullname { get; set; }

        [Required, MinLength(6), MaxLength(15)]
        [RegularExpression("\\d+", ErrorMessage = "Enter valid phonenumber")]
        public string Telephone { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }
        public bool IsAdmin { get; set; } = false;

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<UserCart> UserCarts { get; set; }
    }
}
