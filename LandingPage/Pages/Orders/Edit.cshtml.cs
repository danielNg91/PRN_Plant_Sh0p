using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Constants;
using Persistence.Models;
using Persistence.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantShop.Pages.Orders
{
    [Authorize(Policy = PolicyName.ADMIN)]
    [BindProperties]
    public class EditModel : BasePageModel
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
        public async Task OnGetAsync(string id)
        {
            Order = await _orderRepository.FindByIdAsync(id);
            OrderItems = (List<OrderItem>)await _orderItemRepository.WhereAsync(x => x.OrderId.ToString() == id);
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
