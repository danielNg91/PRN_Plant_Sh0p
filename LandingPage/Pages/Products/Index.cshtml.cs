using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Models;
using Persistence.Repositories;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantShop.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly GenericRepository<Product> _productRepository;
        public List<Product> Products { get; set; }
        public IndexModel(GenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task OnGetAsync()
        {
            Products = await _productRepository.ListAsync();
        }
    }
}
