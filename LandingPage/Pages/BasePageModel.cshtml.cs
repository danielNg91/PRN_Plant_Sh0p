using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Constants;

namespace PlantShop.Pages
{
    public class BasePageModel : PageModel
    {
        [BindProperty]
        public bool IsAdmin => IsCurrentUserAdmin();
        [BindProperty]
        public string CurrentUserId => GetCurrentUserId();

        private bool IsCurrentUserAdmin()
        {
            return User.IsInRole(nameof(Role.Admin));
        }

        private string GetCurrentUserId()
        {
            if (!User.Identity.IsAuthenticated)
            {
                Redirect("Account/Login");
                return null;
            }
            return User.FindFirst(x => x.Type == "id").Value;
        }
    }
}
