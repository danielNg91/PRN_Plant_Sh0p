using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Constants;
using Persistence.Models;
using Persistence.Repositories;
using System.Threading.Tasks;

namespace PlantShop.Pages.Discounts
{

    [Authorize(Policy = PolicyName.ADMIN)]
    public class CreateModel : BasePageModel
    {
        private readonly GenericRepository<ProductDiscount> _discountRepository;
        [BindProperty]
        public ProductDiscount Discount { get; set; }
        
        public CreateModel(GenericRepository<ProductDiscount> discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public async  Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await _discountRepository.CreateAsync(Discount);
                TempData["success"] = "Discount created successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
