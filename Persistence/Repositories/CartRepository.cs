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
        protected readonly ApplicationDbContext _dbContext;

        public CartRepository(ApplicationDbContext dbContext) : base(dbContext)
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
                UserId = Guid.Parse(id),
            };

            _dbContext.UserCarts.Add(newCart);
            await _dbContext.SaveChangesAsync();
            return newCart;

        }

        public async Task<IEnumerable<CartItem>> GetItems(UserCart cart)
        {
            var item = _dbContext.CartItems.Where(item => item.CartId.ToString() == cart.Id.ToString());
            await _dbContext.SaveChangesAsync();
            return item;

        }

        public async Task AddItem(string id, string productId, int quantity = 1)
        {
            var cart = await GetCartByUser(id);

            cart.CartItems.Add(
                    new CartItem
                    {
                        CartId = cart.Id,
                        ProductId = Guid.Parse(productId),
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
