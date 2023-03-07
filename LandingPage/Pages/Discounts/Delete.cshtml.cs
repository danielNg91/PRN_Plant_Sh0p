using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Models;
using Persistence.Repositories;
using System.Threading.Tasks;

namespace PlantShop.Pages.Discounts
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly GenericRepository<ProductDiscount> _discountCategory;
        public ProductDiscount Discount { get; set; }

        public DeleteModel(GenericRepository<ProductDiscount> discountCategory)
        {
			_discountCategory = discountCategory;
        }
        public async Task OnGetAsync(string id)
        {
			Discount = await _discountCategory.FindByIdAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            var discount = await _discountCategory.FindByIdAsync(Discount.Id.ToString());
            if (discount != null)
            {
                await _discountCategory.SoftDeleteAsync(discount);
                TempData["success"] = "Product deleted successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
