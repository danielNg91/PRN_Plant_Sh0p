using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Constants;

namespace PlantShop.Pages
{
    public class BaseModel : PageModel
    {
        protected bool IsAdmin => IsCurrentUserAdmin();
        protected string CurrentUserId => GetCurrentUserId();

        private bool IsCurrentUserAdmin()
        {
            return User.IsInRole(nameof(Role.Admin));
        }

        private string GetCurrentUserId()
        {
            return User.FindFirst(x => x.Type == "id").Value;
        }
    }
}
