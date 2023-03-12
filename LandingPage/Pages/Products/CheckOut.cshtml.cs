using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Constants;
using Persistence.Models;
using Persistence.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantShop.Pages.Products
{
    [Authorize(Policy = PolicyName.CUSTOMER)]
    [BindProperties]
    public class CheckOut : BasePageModel
    {
        private readonly CartRepository _cartRepository;
        private readonly GenericRepository<Order> _orderRepository;
        private readonly GenericRepository<User> _userRepository;
        public User User { get; set; }
        public Order Order { get; set; }
        public UserCart Cart { get; set; }


        public CheckOut(
            CartRepository cartRepository, 
            GenericRepository<Order> orderRepository, 
            GenericRepository<User> userRepository)
        {
            _cartRepository = cartRepository;
            _orderRepository = orderRepository;
            _userRepository = userRepository;

        }

        public async void OnGetAsync(string cartId)
        {
            User = await _userRepository.FindByIdAsync(CurrentUserId);
            Cart = await _cartRepository.FindByIdAsync(cartId);
            Order = await _orderRepository.FirstOrDefaultAsync(o => o.CartId.ToString() == cartId);
        }
        public async Task<IActionResult> OnPostCheckoutAsync()
        {
            Order.PaymentStatus = true;
            await _orderRepository.UpdateAsync(Order);
            return RedirectToPage("Orders/Index");
        }
    }
}