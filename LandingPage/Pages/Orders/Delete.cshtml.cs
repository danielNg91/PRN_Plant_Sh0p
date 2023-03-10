using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Constants;
using Persistence.Models;
using Persistence.Repositories;
using System.Threading.Tasks;

namespace PlantShop.Pages.Orders
{
    [Authorize(Policy = PolicyName.ADMIN)]
    [BindProperties]
    public class DeleteModel : BasePageModel
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
