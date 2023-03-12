using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Models;
using Persistence.Repositories;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Persistence.Constants;

namespace PlantShop.Pages.Products
{
    [Authorize(Policy = PolicyName.ADMIN)]
    public class CreateModel : BasePageModel
    {
        private readonly GenericRepository<Product> _productRepository;
        private readonly GenericRepository<ProductCategory> _categoryRepository;
        private readonly GenericRepository<ProductDiscount> _discountRepository;
        [BindProperty] public Product Product { get; set; }
        public IEnumerable<ProductCategory> Categories { get; set; }
        public IEnumerable<ProductDiscount> Discounts { get; set; }

        public CreateModel(GenericRepository<Product> productRepository, GenericRepository<ProductCategory> categoryRepository, GenericRepository<ProductDiscount> discountRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _discountRepository = discountRepository;
        }
        public async Task OnGetAsync()
        {
            Categories = await _categoryRepository.ListAsync();
            Discounts = await _discountRepository.WhereAsync(x=>x.Active == true);
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await _productRepository.CreateAsync(Product);
                TempData["success"] = "Product created successfully";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}