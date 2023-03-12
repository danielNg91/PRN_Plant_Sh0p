using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Constants;
using Persistence.Models;
using Persistence.Repositories;
using System.Threading.Tasks;

namespace PlantShop.Pages.Categories
{
    [Authorize(Policy = PolicyName.ADMIN)]
    [BindProperties]
    public class EditModel : BasePageModel
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
