using System;
using System.Collections.Generic;

#nullable disable

namespace Persistence.Models
{
    public partial class UserRole : BaseEntity
    {
        public UserRole()
        {
            Users = new HashSet<User>();
        }

        public string Role { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
