using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Constants;
using Persistence.Models;
using Persistence.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantShop.Pages.Categories
{
    [Authorize(Policy = PolicyName.ADMIN)]
    public class IndexModel : BasePageModel
    {
        private readonly GenericRepository<ProductCategory> _categoryRepostory;
        public List<ProductCategory> Categories { get; set; }
        public IndexModel(GenericRepository<ProductCategory> categoryRepostory)
        {
            _categoryRepostory = categoryRepostory;
        }

        public async Task OnGetAsync()
        {
            Categories = await _categoryRepostory.ListAsync();
        }
    }
}
