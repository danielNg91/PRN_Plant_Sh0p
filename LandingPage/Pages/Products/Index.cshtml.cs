using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Models;
using Persistence.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantShop.Pages.Products
{
    public class IndexModel : BasePageModel
    {
        private readonly GenericRepository<Product> _productRepository;
        private readonly GenericRepository<ProductCategory> _productCategoryRepository;
        private readonly GenericRepository<ProductDiscount> _productDiscountCategory;
        private readonly CartRepository _cartRepository;
        public List<Product> ProductList { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public List<ProductDiscount> ProductDiscounts { get; set; }
        public IndexModel(
            GenericRepository<Product> productRepository,
            GenericRepository<ProductCategory> productCategoryRepository,
            GenericRepository<ProductDiscount> productDiscountCategory, 
            CartRepository cartRepository
        ) {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _productDiscountCategory = productDiscountCategory;
            _cartRepository = cartRepository;
        }

        public async Task OnGetAsync()
        {
            ProductList = await _productRepository.ListAsync();
            ProductCategories = await _productCategoryRepository.ListAsync();
            ProductDiscounts = await _productDiscountCategory.ListAsync();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(string Id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("Account/Login");
            }
            var currentUser = User.FindFirst(t => t.Type == "id").Value;
            var item = await _productRepository.FindByIdAsync(Id.ToString());
            await _cartRepository.AddItem(currentUser, item);
            return RedirectToAction("Index");
        }
    }
}
