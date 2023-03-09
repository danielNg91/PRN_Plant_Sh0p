using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Models;
using Persistence.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantShop.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly GenericRepository<Order> _orderRepository;
        private readonly GenericRepository<OrderItem> _orderItemRepository;
        private readonly GenericRepository<Product> _productRepository;
        [BindProperty]
        public Order Order { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public List<Product> Products { get; set; }

        public CreateModel(GenericRepository<Order> orderRepository, GenericRepository<OrderItem> orderItemRepository, GenericRepository<Product> productRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _productRepository = productRepository;
        }

        public async Task OnGetAsync()
        {
            Products = await _productRepository.ListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await _orderRepository.CreateAsync(Order);
                TempData["success"] = "Product created successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
