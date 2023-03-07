using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Models;
using Persistence.Repositories;
using System.Threading.Tasks;

namespace PlantShop.Pages.Cart
{
	[BindProperties]
	public class DeleteModel : PageModel
	{
		private readonly GenericRepository<CartItem> _cartItemRepository;
		public CartItem CartItem { get; set; }
		public DeleteModel(GenericRepository<CartItem> cartItemRepository)
		{
			_cartItemRepository = cartItemRepository;
		}
		public async Task OnGetAsync(int id)
		{
			CartItem = await _cartItemRepository.FindByIdAsync(id);
		}
		public async Task<IActionResult> OnPost()
		{
			var item = await _cartItemRepository.FindByIdAsync(CartItem.Id);
			if (item != null)
			{
				await _cartItemRepository.SoftDeleteAsync(item);
			}
			return Page();
		}
	}
}
