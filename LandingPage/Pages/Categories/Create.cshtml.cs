using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Models;
using Persistence.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantShop.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly GenericRepository<ProductCategory> _categoryRepository;
        public ProductCategory Category { get; set; }

        public CreateModel(GenericRepository<ProductCategory> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                Category.CreatedAt = System.DateTime.Now;
                Category.ModifiedAt = System.DateTime.Now;
                await _categoryRepository.CreateAsync(Category);
                TempData["success"] = "Product created successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
