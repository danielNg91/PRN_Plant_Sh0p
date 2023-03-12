using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Constants;
using Persistence.Models;
using Persistence.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantShop.Pages.Categories
{
    [Authorize(Policy = PolicyName.ADMIN)]
    [BindProperties]
    public class CreateModel : BasePageModel
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
                await _categoryRepository.CreateAsync(Category);
                TempData["success"] = "Product created successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
