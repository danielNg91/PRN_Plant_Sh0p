using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Constants;
using Persistence.Models;
using Persistence.Repositories;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PlantShop.Pages.Login
{
    public class IndexModel : BasePageModel
    {
        private readonly GenericRepository<User> _userRepository;
        public IndexModel(GenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [BindProperty]
        public Credential Credential { get; set; }
        public string Message { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userRepository.FirstOrDefaultAsync(u => u.Username == Credential.UserName);

            if (user != null)
            {
                var passwordHasher = new PasswordHasher<User>();
                if (passwordHasher.VerifyHashedPassword(user, user.Password, Credential.Password) == PasswordVerificationResult.Success)
                {
                    var claims = new List<Claim>
                    {
                        new Claim("id", user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Role, user.IsAdmin ? nameof(Role.Admin) : nameof(Role.Customer))
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties()
                    {
                        IsPersistent = Credential.RememberMe
                    };
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);
                    return RedirectToPage("/Index");
                }
            }

            Message = "Invalid username or password";
            return Page();
        }
    }


    public class Credential
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
