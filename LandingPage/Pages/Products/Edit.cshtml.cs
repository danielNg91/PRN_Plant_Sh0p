using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Models;
using Persistence.Repositories;
using System.Threading.Tasks;

namespace PlantShop.Pages.Products
{
    [BindProperties]
    public class EditModel : BasePageModel
    {
        private readonly GenericRepository<Product> _productRepository;
        private readonly GenericRepository<ProductCategory> _categoryRepository;
        private readonly GenericRepository<ProductDiscount> _discountRepository;
        [BindProperty]
        public Product Product { get; set; }
        public List<ProductCategory> Categories { get; set; }
        public List<ProductDiscount> Discounts { get; set; }

        public EditModel(GenericRepository<Product> productRepository, GenericRepository<ProductCategory> categoryRepository, GenericRepository<ProductDiscount> discountRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _discountRepository = discountRepository;
        }

        public async Task OnGetAsync(string id)
        {
            Product = await _productRepository.FindByIdAsync(id);
            Categories = await _categoryRepository.ListAsync();
            Discounts = (List<ProductDiscount>) await _discountRepository.WhereAsync(x=>x.Active == true);
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
