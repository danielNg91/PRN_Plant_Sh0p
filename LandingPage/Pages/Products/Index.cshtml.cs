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
using Persistence.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using PlantShop.Pages.Cart;

namespace PlantShop.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly GenericRepository<Product> _productRepository;
        private readonly GenericRepository<ProductCategory> _productCategoryRepository;
        private readonly GenericRepository<ProductDiscount> _productCategoryDiscount;
        private readonly GenericRepository<CartItem> _cartItemRepository;
        public UserCart Cart { get; set; }
        public List<CartItem> CartItems { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public List<ProductDiscount> ProductDiscounts { get; set; }

        public IndexModel(GenericRepository<Product> productRepository, GenericRepository<ProductCategory> productCategoryRepository, GenericRepository<ProductDiscount> productCategoryDiscount, GenericRepository<CartItem> cartItemRepository)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _productCategoryDiscount = productCategoryDiscount;
            _cartItemRepository = cartItemRepository;
        }
        public async Task OnGetAsync()
        {
            Products = await _productRepository.ListAsync();
            ProductCategories = await _productCategoryRepository.ListAsync();
            ProductDiscounts = await _productCategoryDiscount.ListAsync();
        }
        public async Task<IActionResult> AddToCart(string id, [FromServices] CartViewModel cartViewModel)
        {
            var item = await _cartItemRepository.FindByIdAsync(id);
            cartViewModel.AddItem(item);
            return await Task.FromResult<IActionResult>(RedirectToPage("Cart/Index"));
        }
    }

    public class CartViewModel
    {
        private readonly UserCartService _cartService;

        public CartViewModel(UserCartService cartService)
        {
            _cartService = cartService;
        }

        public UserCart Cart { get; } = new UserCart();

        public void AddItem(CartItem item)
        {
            _cartService.AddItem(Cart, item);
        }

        public void RemoveItem(CartItem item)
        {
            _cartService.RemoveItem(Cart, item);
        }

        public decimal GetTotalCost()
        {
            return _cartService.GetTotalCost(Cart);
        }
    }



}
