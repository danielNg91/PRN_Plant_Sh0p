using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CartRepository : GenericRepository<UserCart>
    {
        private readonly GenericRepository<Order> _orderRepository;
        private readonly GenericRepository<CartItem> _itemRepository;
        public CartRepository(
            ApplicationDbContext dbContext,
            GenericRepository<Order> orderRepository,
            GenericRepository<CartItem> itemRepository
        ) : base(dbContext)
        {
            _orderRepository = orderRepository;
            _itemRepository = itemRepository;
        }

        public async Task<UserCart> GetCartByUser(string id)
        {
            var order = await _orderRepository.FirstOrDefaultAsync(o => o.UserId.ToString() == id && !o.PaymentStatus);
            if (order != null)
            {
                var currentCart = await GetCart(order.CartId.ToString());
                return currentCart;
            }

            // if it is first attempt create new
            var cart = new UserCart
            {
                UserId = Guid.Parse(id),
            };
            await CreateAsync(cart);
            await _orderRepository.CreateAsync(new Order
            {
                CartId = cart.Id,
                UserId = Guid.Parse(id),
            });
            return cart;
        }

        public async Task<UserCart> GetCart(string id)
        {
            var cart = await FindByIdAsync(id);
            var items = await _itemRepository.WhereAsync(i => i.CartId.ToString() == cart.Id.ToString(), nameof(CartItem.Product));
            cart.CartItems = items;
            return cart;
        }

        public async Task AddItem(string userId, Product product, int quantity = 1)
        {
            var cart = await GetCartByUser(userId);
            var itemExist = cart.CartItems.FirstOrDefault(i => i.ProductId == product.Id);
            if (itemExist != null && itemExist.Quantity > 0)
            {
                itemExist.Quantity++;
            }
            else
            {
                cart.CartItems.Add(new CartItem
                {
                    CartId = cart.Id,
                    ProductId = product.Id,
                    Quantity = quantity,
                    CreatedAt = DateTime.Now,
                });
            }

            await UpdateAsync(cart);
        }

        public async Task RemoveItem(string id, string cartItemId)
        {
            var cart = await GetCartByUser(id);

            if (cart != null)
            {
                var removedItem = cart.CartItems.FirstOrDefault(x => x.Id.ToString() == cartItemId);
                cart.CartItems.Remove(removedItem);
                await UpdateAsync(cart);
            }
        }

        public async Task ClearCart(string id)
        {
            var cart = await GetCartByUser(id);
            cart.CartItems.Clear();
            await UpdateAsync(cart);

            //_context.Entry(cart).State = EntityState.Modified;
            //await _context.SaveChangesAsync();
        }

        public async Task IncreaseAmount(string id, string itemId)
        {
            var cart = await GetCartByUser(id);
            var itemExist = cart.CartItems.FirstOrDefault(i => i.Product.Id.ToString() == itemId);
            if (itemExist != null && itemExist.Quantity > 0)
            {
                itemExist.Quantity++;
            }
            await UpdateAsync(cart);

        }
        public async Task DecreaseAmount(string id, string itemId)
        {
            var cart = await GetCartByUser(id);
            var itemExist = cart.CartItems.FirstOrDefault(i => i.Product.Id.ToString() == itemId);
            if (itemExist != null && itemExist.Quantity > 0)
            {
                itemExist.Quantity--;
            }
            if (itemExist != null && itemExist.Quantity < 0)
            {
                await RemoveItem(id, itemExist.Id.ToString());
            }
            await UpdateAsync(cart);
        }
    }
}
