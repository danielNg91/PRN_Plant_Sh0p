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
        [BindProperty]
        public Product Product { get; set; }

        public EditModel(GenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task OnGetAsync(int id)
        {
            Product = await _productRepository.FindByIdAsync(id);
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
