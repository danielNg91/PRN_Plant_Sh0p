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

        //public async Task<IActionResult> OnPostRemoveToCartAsync(int cartId, int cartItemId)
        //{
        //    await _cartRepository.RemoveItem(cartId, cartItemId);
        //    return RedirectToPage();
        //}
    }
}
