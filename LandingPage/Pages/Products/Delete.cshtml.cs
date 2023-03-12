using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Models;
using Persistence.Repositories;
using System.Threading.Tasks;

namespace PlantShop.Pages.Products
{
    [BindProperties]
    public class DeleteModel : BasePageModel
    {
        private readonly GenericRepository<Product> _productRepository;
        public Product Product { get; set; }

        public DeleteModel(GenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task OnGetAsync(string id)
        {
            Product = await _productRepository.FindByIdAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            var product = await _productRepository.FindByIdAsync(Product.Id.ToString());
            if (product != null)
            {
                await _productRepository.SoftDeleteAsync(product);
                TempData["success"] = "Product deleted successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
