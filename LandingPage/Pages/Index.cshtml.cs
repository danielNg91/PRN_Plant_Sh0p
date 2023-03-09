using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistence.Models;
using Persistence.Repositories;

namespace PlantShop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly GenericRepository<Product> _productRepository;
        private readonly GenericRepository<ProductCategory> _productCategoryRepository;
        private readonly GenericRepository<ProductDiscount> _productDiscountRepository;

        public List<Product> Products { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public List<ProductDiscount> ProductDiscounts { get; set; }
        public List<CartItem> CartItems { get; set; }


        public IndexModel(ILogger<IndexModel> logger, GenericRepository<Product> productRepository, GenericRepository<ProductCategory> productCategoryRepository, GenericRepository<ProductDiscount> productDiscountRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _productDiscountRepository = productDiscountRepository;
        }

        public async Task OnGetAsync()
        {
            Products = await _productRepository.ListAsync();
            ProductCategories = await _productCategoryRepository.ListAsync();
            ProductDiscounts = await _productDiscountRepository.ListAsync();
        }
    }
}
