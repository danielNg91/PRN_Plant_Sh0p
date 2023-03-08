using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Models;
using Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CartRepository : ICartRepository
    {
        protected readonly ApplicationDbContext _dbContext;

        public CartRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserCart> GetCartByUser(string id)
        {
            var cart = _dbContext.UserCarts
                        .Include(c => c.CartItems)
                            .ThenInclude(i => i.Product)
                        .FirstOrDefault(c => c.UserId.ToString() == id);

            if (cart != null)
                return cart;

            // if it is first attempt create new
            var newCart = new UserCart
            {
                UserId = int.Parse(id)
            };

            _dbContext.UserCarts.Add(newCart);
            await _dbContext.SaveChangesAsync();
            return newCart;
        }

        public async Task AddItem(string id, int productId, int quantity = 1)
        {
            var cart = await GetCartByUser(id);

            cart.CartItems.Add(
                    new CartItem
                    {
                        CartId = cart.Id,
                        ProductId = productId,
                        Quantity = quantity
                    }
                );

            _dbContext.Entry(cart).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveItem(Guid cartId, Guid cartItemId)
        {
            var cart = _dbContext.UserCarts
                       .Include(c => c.CartItems)
                       .FirstOrDefault(c => c.Id == cartId);

            if (cart != null)
            {
                var removedItem = cart.CartItems.FirstOrDefault(x => x.Id == cartItemId);
                cart.CartItems.Remove(removedItem);

                _dbContext.Entry(cart).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }

        }

        public async Task ClearCart(string id)
        {
            var cart = await GetCartByUser(id);

            cart.CartItems.Clear();

            _dbContext.Entry(cart).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
