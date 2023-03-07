using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Models;
using Persistence.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantShop.Pages.Cart
{
    public class IndexModel : PageModel
    {
        private readonly GenericRepository<UserCart> _cartRepository;
        private readonly GenericRepository<CartItem> _cartItemRepository;
        private readonly GenericRepository<Product> _productRepository;
        public UserCart Cart { get; set; }
        public List<CartItem> CartItems { get; set; }
        public List<Product> Products { get; set; }
        public IndexModel(GenericRepository<Product> productRepository, GenericRepository<UserCart> cartRepository, GenericRepository<CartItem> cartItemRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _cartItemRepository = cartItemRepository;
        }
        public async Task OnGetAsync(int id)
        {
            var claim = User.FindFirst(t => t.Type == "id");
            Cart = await _cartRepository.FirstOrDefaultAsync(c => c.UserId.ToString() == claim.ToString());
            Cart ??= new UserCart();
            CartItems = (List<CartItem>)await _cartItemRepository.WhereAsync(c => c.CartId == Cart.Id);
        }
    }
}
