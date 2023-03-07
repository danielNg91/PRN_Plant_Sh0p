using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Models;
using Persistence.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantShop.Pages.Orders
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly GenericRepository<Order> _orderRepository;
        private readonly GenericRepository<OrderItem> _orderItemRepository;
        [BindProperty]
        public Order Order { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public EditModel(GenericRepository<Order> orderRepository, GenericRepository<OrderItem> orderItemRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
        }
        public async Task OnGetAsync(int id)
        {
            Order = await _orderRepository.FindByIdAsync(id);
            OrderItems = (List<OrderItem>)await _orderItemRepository.WhereAsync(x => x.OrderId == id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await _orderRepository.UpdateAsync(Order);
                TempData["success"] = "Order updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
