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
        public UserCart Cart { get; set; }
        public string Message { get; set; }
        public CartModel(CartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task OnGetAsync()
        {
            var currentUser = User.FindFirst(x => x.Type == "id").Value;
            Cart = await _cartRepository.GetCartByUser(currentUser);
        }
        public async Task<IActionResult> OnPostRemoveItemAsync(string Id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("Account/Login");
            }
            var currentUser = User.FindFirst(t => t.Type == "id").Value;
            var cart = await _cartRepository.GetCartByUser(currentUser);
            await _cartRepository.RemoveItem(currentUser, Id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> OnPostClearItemAsync()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("Account/Login");
            }
            var currentUser = User.FindFirst(x => x.Type == "id").Value;
            var cart = await _cartRepository.GetCartByUser(currentUser);
            if (cart.CartItems.Count > 0)
            {
                await _cartRepository.ClearCart(currentUser);
                return RedirectToPage("Cart");
            }
            return Page();
        }


        //public async Task<IActionResult> OnPostRemoveToCartAsync(int cartId, int cartItemId)
        //{
        //    await _cartRepository.RemoveItem(cartId, cartItemId);
        //    return RedirectToPage();
        //}
    }
}
