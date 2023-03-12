using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Models;
using Persistence.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlantShop.Pages.Products
{
    public class CheckOut : BasePageModel
    {
        private readonly CartRepository _cartRepository;
        private readonly GenericRepository<CartItem> _cartItemRepository;
        private readonly GenericRepository<Order> _orderRepository;
        private readonly GenericRepository<OrderItem> _orderItemRepository;

        public CheckOut(CartRepository cartRepository, GenericRepository<CartItem> cartItemRepository, GenericRepository<Order> orderRepository, GenericRepository<OrderItem> orderItemRepository)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
        }

        public UserCart Cart { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public Order Order { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                //execute to create order


                //----------------------------------------------------------------
                TempData["success"] = "Product created successfully";
                return RedirectToPage("Cart/Index");
            }
            return Page();
        }
    }
}
