using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistence.Models;
using Persistence.Repositories;
using System.Threading.Tasks;

namespace PlantShop.Pages.Signup
{
    public class IndexModel : PageModel
    {
        private readonly GenericRepository<User> _userRepository;
        [BindProperty] public User User { get; set; }
        public string Message { get; set; }
        public bool IsAdmin { get; set; }


        public IndexModel(GenericRepository<User> userRepository)
        {
            IsAdmin = false;
            _userRepository = userRepository;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if ( 
                User != null &&
                User.Username != null &&
                User.Password != null &&
                User.Fullname != null &&
                User.Telephone != null &&
                User.Email != null &&
                User.Address != null &&
                User.Username.Trim() != "" &&
                User.Password.Trim() != "" &&
                User.Fullname.Trim() != "" &&
                User.Telephone.Trim() != "" &&
                User.Email.Trim() != "" &&
                User.Address.Trim() != ""
            )
            {
                var user = await _userRepository.FirstOrDefaultAsync(u => u.Username == User.Username);
                if (user == null)
                {
                    var passwordHasher = new PasswordHasher<User>();
                    User.Password = passwordHasher.HashPassword(User, User.Password);
                    await _userRepository.CreateAsync(User);
                    TempData["success"] = "User created successfully";

                    return RedirectToPage("/Account/Login");
                }
                Message = "Username existed";
                return Page();
            }

            Message = "Don't leave any field emmpty";
            return Page();
        }
    }
}
