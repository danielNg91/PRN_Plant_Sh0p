using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Models;
using Persistence.Repositories;
using System.Threading.Tasks;

namespace PlantShop.Pages.Orders
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly GenericRepository<Order> _orderCategory;
        public Order Order { get; set; }

        public DeleteModel(GenericRepository<Order> orderCategory)
        {
            _orderCategory = orderCategory;
        }
        public async Task OnGetAsync(string id)
        {
            Order = await _orderCategory.FindByIdAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            var order = await _orderCategory.FindByIdAsync(Order.Id.ToString());
            if (order != null)
            {
                await _orderCategory.SoftDeleteAsync(order);
                TempData["success"] = "Product deleted successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
