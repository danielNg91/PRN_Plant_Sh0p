using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Models;
using Persistence.Repositories;
using System.Threading.Tasks;

namespace PlantShop.Pages.Orders
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly GenericRepository<Order> _orderRepository;
        [BindProperty]
        public Order Order { get; set; }

        public EditModel(GenericRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task OnGetAsync(string id)
        {
            Order = await _orderRepository.FindByIdAsync(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await _orderRepository.UpdateAsync(Order);
                TempData["success"] = "Category updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
