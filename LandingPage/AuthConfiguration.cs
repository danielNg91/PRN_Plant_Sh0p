using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Constants;
using System.Security.Claims;

namespace PlantShop
{
    public static class AuthConfiguration
    {
        public static void AddAppAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(PolicyName.ADMIN, 
                    policy => policy.RequireClaim(ClaimTypes.Role, nameof(Roles.Admin)));
                options.AddPolicy(PolicyName.CUSTOMER,
                    policy => policy.RequireClaim(ClaimTypes.Role, nameof(Roles.Customer)));
            });
            services.AddRazorPages((options) =>
            {
                options.Conventions.AuthorizeFolder("/Products").AllowAnonymousToPage("/Products/Index");
                options.Conventions.AuthorizeFolder("/Categories");
                options.Conventions.AuthorizeFolder("/Discounts");
            });
        }
        public static void AddAppAuthentication(this IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => {
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
            });
        }
    }
}
