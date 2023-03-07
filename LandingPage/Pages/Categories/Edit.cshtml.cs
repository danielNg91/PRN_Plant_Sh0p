using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Models;
using Persistence.Repositories;
using System.Threading.Tasks;

namespace PlantShop.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly GenericRepository<ProductCategory> _categoryRepository;
        [BindProperty]
        public ProductCategory Category { get; set; }

        public EditModel(GenericRepository<ProductCategory> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task OnGetAsync(string id)
        {
            Category = await _categoryRepository.FindByIdAsync(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.UpdateAsync(Category);
                TempData["success"] = "Category updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
