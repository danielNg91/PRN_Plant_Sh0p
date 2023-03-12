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
    public class CartModel : BasePageModel
    {
        private readonly CartRepository _cartRepository;
        private readonly GenericRepository<ProductDiscount> _productDiscountRepository;
        public UserCart Cart { get; set; }
        public List<ProductDiscount> ProductDiscounts { get; set; }
        public CartModel(CartRepository cartRepository, GenericRepository<ProductDiscount> productDiscountRepository, GenericRepository<CartItem> cartItemRepository)
        {
            _cartRepository = cartRepository;
            _productDiscountRepository = productDiscountRepository;
        }
        public async Task OnGetAsync()
        {
            ProductDiscounts = await _productDiscountRepository.ListAsync();
            var currentUser = User.FindFirst(x => x.Type == "id").Value;
            Cart = await _cartRepository.GetCartByUser(currentUser);
        }
        
        public async Task<IActionResult> OnPostRemoveItemAsync(string Id)
        {
            await _cartRepository.RemoveItem(CurrentUserId, Id);
            return RedirectToPage("Cart");
        }

        public async Task<IActionResult> OnPostClearItemAsync()
        {
            await _cartRepository.ClearCart(CurrentUserId);
            return RedirectToPage("Cart");
        }

        public async Task<IActionResult> OnPostIncreaseAmountAsync(string Id)
        {
            await _cartRepository.IncreaseAmount(CurrentUserId, Id);
            return RedirectToPage("Cart");
        }

        public async Task<IActionResult> OnPostDecreaseAmountAsync(string Id)
        {
            await _cartRepository.DecreaseAmount(CurrentUserId, Id);
            return RedirectToPage("Cart");
        }
    }
}
