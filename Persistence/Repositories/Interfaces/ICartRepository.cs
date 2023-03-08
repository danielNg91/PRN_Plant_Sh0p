using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Task<UserCart> GetCartByUser(string id);
        Task AddItem(string id, int productId, int quantity = 1);
        Task RemoveItem(Guid cartId, Guid cartItemId);
        Task ClearCart(string id);
    }
}
