using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Constants;
using Persistence.Models;
using Persistence.Repositories;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantShop.Pages.Orders
{
    public class IndexModel : BaseModel
    {
        private readonly GenericRepository<Order> _orderRepository;

        public List<Order> Orders { get; set; }

        public IndexModel(GenericRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task OnGetAsync()
        {
            if (IsAdmin)
            {
                Orders = (List<Order>)await _orderRepository.WhereAsync(_ => true, nameof(Order.User), nameof(Order.UserCart));
            }
            else
            {
                Orders = (List<Order>)await _orderRepository.WhereAsync(
                    o => o.UserId.ToString() == CurrentUserId, 
                    nameof(Order.User),
                    nameof(Order.UserCart)
                    );
            }
        }
    }
}
