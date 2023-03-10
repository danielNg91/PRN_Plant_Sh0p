using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CartRepository : GenericRepository<UserCart>
    {
        public CartRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<UserCart> GetCartByUser(string id)
        {
            var cart = _context.UserCarts
                        .Include(c => c.CartItems)
                            .ThenInclude(i => i.Product)
                        .FirstOrDefault(c => c.UserId.ToString() == id);

            if (cart != null)
                return cart;

            // if it is first attempt create new
            var newCart = new UserCart
            {
                UserId = Guid.Parse(id),
            };

            _context.UserCarts.Add(newCart);
            await _context.SaveChangesAsync();
            return newCart;

        }

        public async Task AddItem(string userId, Guid productId, int quantity = 1)
        {
            var cart = await GetCartByUser(userId);

            cart.CartItems.Add(
                    new CartItem
                    {
                        CartId = cart.Id,
                        ProductId = productId,
                        Quantity = quantity
                    }
                );

            _context.Entry(cart).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveItem(string cartId, string cartItemId)
        {
            var cart = _context.UserCarts
                       .Include(c => c.CartItems)
                       .FirstOrDefault(c => c.Id.ToString() == cartId);

            if (cart != null)
            {
                var removedItem = cart.CartItems.FirstOrDefault(x => x.Id.ToString() == cartItemId);
                cart.CartItems.Remove(removedItem);

                _context.Entry(cart).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

        }

        public async Task ClearCart(string id)
        {
            var cart = await GetCartByUser(id);

            cart.CartItems.Clear();

            _context.Entry(cart).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
