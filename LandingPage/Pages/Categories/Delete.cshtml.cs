using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Models;
using Persistence.Repositories;
using System.Threading.Tasks;

namespace PlantShop.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly GenericRepository<ProductCategory> _categoryRepository;
        public ProductCategory Category { get; set; }

        public DeleteModel(GenericRepository<ProductCategory> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task OnGetAsync(int id)
        {
            Category = await _categoryRepository.FindByIdAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            var category = await _categoryRepository.FindByIdAsync(Category.Id);
            if (category != null)
            {
                await _categoryRepository.SoftDeleteAsync(category);
                TempData["success"] = "Category deleted successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
