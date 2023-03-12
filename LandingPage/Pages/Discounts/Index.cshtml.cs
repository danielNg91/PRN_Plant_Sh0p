using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Models;
using Persistence.Repositories;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantShop.Pages.Discounts
{
    public class IndexModel : BasePageModel
    {
        private readonly GenericRepository<ProductDiscount> _discountRepository;
        public List<ProductDiscount> Discounts { get; set; }
        public IndexModel(GenericRepository<ProductDiscount> discountRepository)
        {
            _discountRepository = discountRepository;
        }
        public async Task OnGetAsync()
        {
            Discounts = await _discountRepository.ListAsync();
        }
    }
}
