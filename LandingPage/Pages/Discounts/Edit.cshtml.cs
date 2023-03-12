using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Models;
using Persistence.Repositories;
using System.Threading.Tasks;

namespace PlantShop.Pages.Discounts
{
    [BindProperties]
    public class EditModel : BasePageModel
    {
        private readonly GenericRepository<ProductDiscount> _discountRepository;
        [BindProperty]
        public ProductDiscount Discount { get; set; }

        public EditModel(GenericRepository<ProductDiscount> discountRepository)
        {
            _discountRepository = discountRepository;
        }
        public async Task OnGetAsync(string id)
        {
            Discount = await _discountRepository.FindByIdAsync(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await _discountRepository.UpdateAsync(Discount);
                TempData["success"] = "Category updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
