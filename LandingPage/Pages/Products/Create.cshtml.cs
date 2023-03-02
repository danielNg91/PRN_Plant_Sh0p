using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Models;
using Persistence.Repositories;
using System.Threading.Tasks;

namespace PlantShop.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly GenericRepository<Product> _productRepository;
        private readonly GenericRepository<ProductCategory> _categoryRepository;
        [BindProperty] public Product Product { get; set; }
        public IEnumerable<ProductCategory> Categories { get; set; }

        public CreateModel(GenericRepository<Product> productRepository, GenericRepository<ProductCategory> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task OnGetAsync()
        {
            Categories = await _categoryRepository.ListAsync();
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