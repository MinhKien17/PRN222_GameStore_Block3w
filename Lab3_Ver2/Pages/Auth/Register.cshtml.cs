using BusinessLayer.Service.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessLayer.DTO;

namespace GameStore_SE170383_DoanMinhKien.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userService;

        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public BusinessLayer.DTO.RegisterRequest Input { get; set; } 

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            // Call service to register
            var userDto = await _userService.RegisterUser(Input);

            if (userDto == null)
            {
                // registration failed (likely duplicate email)
                ModelState.AddModelError(string.Empty, "Registration failed. Email may already exist.");
                return Page();
            }

            // Option: automatically sign in after successful registration
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userDto.Id.ToString()),
                new Claim(ClaimTypes.Name, userDto.Email),
                new Claim(ClaimTypes.Role, userDto.Role ?? "Customer")
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return LocalRedirect(Url.Content("~/Auth/login"));
        }
    }
}
