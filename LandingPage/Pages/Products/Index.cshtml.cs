using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Models;
using Persistence.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;

namespace PlantShop.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly GenericRepository<Product> _productRepository;
        private readonly GenericRepository<ProductCategory> _productCategoryRepository;
        private readonly GenericRepository<ProductDiscount> _productCategoryDiscount;
        private readonly GenericRepository<UserCart> _cartRepository;
        private readonly GenericRepository<CartItem> _cartItemRepository;
        public UserCart Cart { get; set; }
        public List<CartItem> CartItems { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public List<ProductDiscount> ProductDiscounts { get; set; }
        public IndexModel(GenericRepository<Product> productRepository, GenericRepository<ProductCategory> productCategoryRepository, GenericRepository<ProductDiscount> productCategoryDiscount, GenericRepository<UserCart> cartRepository, GenericRepository<CartItem> cartItemRepository)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _productCategoryDiscount = productCategoryDiscount;
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
        }
        public async Task OnGetAsync()
        {
            Products = await _productRepository.ListAsync();
            ProductCategories = await _productCategoryRepository.ListAsync();
            ProductDiscounts = await _productCategoryDiscount.ListAsync();

            var claim = User.FindFirst(t => t.Type == "id");
            Cart = await _cartRepository.FirstOrDefaultAsync(c => c.UserId.ToString() == claim.ToString());
            Cart ??= new UserCart();
            CartItems = (List<CartItem>)await _cartItemRepository.WhereAsync(c => c.CartId == Cart.Id);
        }

        //Add to cart
        public async Task<IActionResult> AddToCart(int id)
        {
            var product = await _productRepository.FindByIdAsync(id);
            if (product != null)
            {
                AddItem(product);
            }
            return Page();
        }

        public void AddItem(Product Product)
        {
            var item = CartItems.SingleOrDefault(p => p.ProductId == Product.Id);
            if (item == null)
            {
                CartItems.Add(new CartItem { Product = Product, Quantity = 1 });
            }
            else { item.Quantity += 1; }
        }
    }

}
