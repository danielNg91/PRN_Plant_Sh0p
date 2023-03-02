using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Models;
using Persistence.Repositories;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantShop.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly GenericRepository<Order> _orderRepository;
        public List<Order> Orders { get; set; }
        public IndexModel(GenericRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task OnGetAsync()
        {
            Orders = await _orderRepository.ListAsync();
        }
    }
}
