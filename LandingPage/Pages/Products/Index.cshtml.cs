using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Models;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantShop.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly GenericRepository<Product> _productRepository;
        private readonly GenericRepository<ProductCategory> _productCategoryRepository;
        private readonly GenericRepository<ProductDiscount> _productDiscountCategory;
        private readonly CartRepository _cart;
        public UserCart Cart { get; set; }
        public List<CartItem> CartItems { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }

        public List<ProductDiscount> ProductDiscounts { get; set; }
        [BindProperty]
        public int Quantity { get; set; }

        public IndexModel(GenericRepository<Product> productRepository, GenericRepository<ProductCategory> productCategoryRepository, GenericRepository<ProductDiscount> productDiscountCategory, CartRepository cart)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _productDiscountCategory = productDiscountCategory;
            _cart = cart;
        }

        public async Task OnGetAsync()
        {
            Products = await _productRepository.ListAsync();
            ProductCategories = await _productCategoryRepository.ListAsync();
            ProductDiscounts = await _productDiscountCategory.ListAsync();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(Guid id)
        {
            var currentUser = User.FindFirst(t => t.Type == "id").Value;
            await _cart.AddItem(currentUser, id, Quantity);
            return Page();
        }
    }
}
