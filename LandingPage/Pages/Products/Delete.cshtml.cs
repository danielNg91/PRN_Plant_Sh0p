using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Models;
using Persistence.Repositories;
using System.Threading.Tasks;

namespace PlantShop.Pages.Products
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly GenericRepository<Product> _productCategory;
        public Product Product { get; set; }

        public DeleteModel(GenericRepository<Product> productCategory)
        {
            _productCategory = productCategory;
        }
        public async Task OnGetAsync(int id)
        {
            Product = await _productCategory.FindByIdAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            var product = await _productCategory.FindByIdAsync(Product.Id);
            if (product != null)
            {
                await _productCategory.SoftDeleteAsync(product);
                TempData["success"] = "Product deleted successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
