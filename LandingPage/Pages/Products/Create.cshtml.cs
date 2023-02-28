using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Models;
using Persistence.Repositories;
using System.Threading.Tasks;

namespace PlantShop.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly GenericRepository<Product> _productRepository;
        [BindProperty]
        public Product Product { get; set; }
        
        public CreateModel(GenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async  Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await _productRepository.CreateAsync(Product);
                TempData["success"] = "Product created successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
