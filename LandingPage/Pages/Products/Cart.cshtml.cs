using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Models;
using Persistence.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantShop.Pages.Products
{
    public class CartModel : PageModel
    {
        private readonly CartRepository _cartRepository;
        private readonly GenericRepository<ProductDiscount> _productDiscountRepository;
        private readonly GenericRepository<CartItem> _cartItemRepository;
        public UserCart Cart { get; set; }
        public List<ProductDiscount> ProductDiscounts { get; set; }
        public CartModel(CartRepository cartRepository, GenericRepository<ProductDiscount> productDiscountRepository, GenericRepository<CartItem> cartItemRepository)
        {
            _cartRepository = cartRepository;
            _productDiscountRepository = productDiscountRepository;
            _cartItemRepository = cartItemRepository;
        }
        public async Task OnGetAsync()
        {
            ProductDiscounts = await _productDiscountRepository.ListAsync();
            var currentUser = User.FindFirst(x => x.Type == "id").Value;
            Cart = await _cartRepository.GetCartByUser(currentUser);
        }

        private string getCurrentUserId()
        {
            if (!User.Identity.IsAuthenticated)
            {
                Redirect("Account/Login");
                return null;
            }
            return User.FindFirst(x => x.Type == "id").Value;
        }
        
        public async Task<IActionResult> OnPostRemoveItemAsync(string Id)
        {
            var currentUser = getCurrentUserId();
            await _cartRepository.RemoveItem(currentUser, Id);
            return RedirectToPage("Cart");
        }

        public async Task<IActionResult> OnPostClearItemAsync()
        {
            var currentUser = getCurrentUserId();
            await _cartRepository.ClearCart(currentUser);
            return RedirectToPage("Cart");
        }

        public async Task<IActionResult> OnPostIncreaseAmountAsync(string Id)
        {
            var currentUser = getCurrentUserId();
            await _cartRepository.IncreaseAmount(currentUser, Id);
            return RedirectToPage("Cart");
        }

        public async Task<IActionResult> OnPostDecreaseAmountAsync(string Id)
        {
            var currentUser = getCurrentUserId();
            await _cartRepository.DecreaseAmount(currentUser, Id);
            return RedirectToPage("Cart");
        }
    }
}
