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
        [BindProperty]
        public Order Order { get; set; }
        public List<OrderItem> Items { get; set; }

        public CreateModel(GenericRepository<Order> orderRepository, GenericRepository<OrderItem> orderItemRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
        }

        //public async Task<IActionResult> OnGetAsync()
        //{
        //    Items = await _orderItemRepository.ListAsync();
        //}

        public async  Task<IActionResult> OnPostAsync()
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
