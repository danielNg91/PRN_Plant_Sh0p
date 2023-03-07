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
        private readonly GenericRepository<User> _userRepository;
        public List<Order> Orders { get; set; }
        public List<User> Users { get; set; }
        public IndexModel(GenericRepository<Order> orderRepository, GenericRepository<User> userRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }
        public async Task OnGetAsync()
        {
            Orders = await _orderRepository.ListAsync();
            Users = await _userRepository.ListAsync();
        }
    }
}
