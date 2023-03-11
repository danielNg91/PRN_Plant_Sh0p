using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Models;
using Persistence.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantShop.Pages.Products
{
    public class CartModel : PageModel
    {
        private readonly CartRepository _cartRepository;
        private readonly GenericRepository<CartItem> _cartItemRepository;
        private readonly GenericRepository<Order> _orderRepository;
        public UserCart Cart { get; set; }
        public string Message { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        public CartModel(CartRepository cartRepository, GenericRepository<CartItem> cartItemRepository, GenericRepository<Order> orderRepository)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _orderRepository = orderRepository;
        }
        public async Task OnGetAsync()
        {
            var currentUser = User.FindFirst(x => x.Type == "id").Value;
            var order = await _orderRepository.FirstOrDefaultAsync(order => order.UserId.Equals(currentUser));
            if (order == null)
            {
                Cart = await _cartRepository.FindByIdAsync(Cart.Id.ToString(), nameof(UserCart.CartItems));
            }
        }

        //public async Task<IActionResult> OnPostRemoveToCartAsync(int cartId, int cartItemId)
        //{
        //    await _cartRepository.RemoveItem(cartId, cartItemId);
        //    return RedirectToPage();
        //}
    }
}
