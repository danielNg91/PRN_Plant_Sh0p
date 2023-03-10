using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Models;
using Persistence.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantShop.Pages.Cart
{
    public class IndexModel : PageModel
    {
        private readonly CartRepository _cartRepository;
        private readonly GenericRepository<CartItem> _cartItemRepository;
        public UserCart Cart { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        public List<Product> Products { get; set; }
        public IndexModel(CartRepository cartRepository, GenericRepository<CartItem> cartItemRepository)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
        }
        public async Task OnGetAsync()
        {
            var currentUser = User.FindFirst(t => t.Type == "id").Value;
            Cart = await _cartRepository.GetCartByUser(currentUser);

        }
    }
}