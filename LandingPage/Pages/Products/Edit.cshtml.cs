using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Models;
using Persistence.Repositories;
using System.Threading.Tasks;

namespace PlantShop.Pages.Products
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly GenericRepository<Product> _productRepository;
        private readonly GenericRepository<ProductCategory> _categoryRepository;
        [BindProperty]
        public Product Product { get; set; }
        public IEnumerable<ProductCategory> Categories { get; set; }

        public EditModel(GenericRepository<Product> productRepository, GenericRepository<ProductCategory> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task OnGetAsync(int id)
        {
            Product = await _productRepository.FindByIdAsync(id);
            Categories = await _categoryRepository.ListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await _productRepository.UpdateAsync(Product);
                TempData["success"] = "Category updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
