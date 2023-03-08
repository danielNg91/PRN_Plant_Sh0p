using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services
{
    public class UserCartService
    {
        public void AddItem(UserCart cart, CartItem item)
        {
            cart.CartItems.Add(item);
        }

        public void RemoveItem(UserCart cart, CartItem item)
        {
            cart.CartItems.Remove(item);
        }

        public decimal GetTotalCost(UserCart cart)
        {
            return cart.CartItems.Sum(i => (i.Quantity * i.Product.Price));
        }
    }
}
