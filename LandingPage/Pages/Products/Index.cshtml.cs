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
using Microsoft.AspNetCore.Cors.Infrastructure;
using PlantShop.Pages.Cart;
using Persistence.Repositories.Interfaces;

namespace PlantShop.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly GenericRepository<Product> _productRepository;
        private readonly GenericRepository<ProductCategory> _productCategoryRepository;
        private readonly GenericRepository<ProductDiscount> _productDiscountCategory;
        private readonly GenericRepository<UserCart> _cartRepository;
        private readonly ICartRepository _cart;
        public UserCart Cart { get; set; }
        public List<CartItem> CartItems { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public List<ProductDiscount> ProductDiscounts { get; set; }

        public IndexModel(GenericRepository<Product> productRepository, GenericRepository<ProductCategory> productCategoryRepository, GenericRepository<ProductDiscount> productDiscountCategory, GenericRepository<UserCart> cartRepository, ICartRepository cart)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _productDiscountCategory = productDiscountCategory;
            _cartRepository = cartRepository;
            _cart = cart;
        }

        public async Task OnGetAsync()
        {
            Products = await _productRepository.ListAsync();
            ProductCategories = await _productCategoryRepository.ListAsync();
            ProductDiscounts = await _productDiscountCategory.ListAsync();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(int id)
        {
            string currentUser = User.FindFirst(t => t.Type == "id").Value;

            await _cart.AddItem(currentUser, id);
            return Page();
        }
    }
}
