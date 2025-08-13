using System.Security.Claims;
using BusinessLayer.DTO;
using BusinessLayer.Service.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameStore_SE170383_DoanMinhKien.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;
        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }
        [BindProperty]
        public LoginRequest Input { get; set; } = new();

        public string ReturnUrl { get; set; } = "/";

        public void OnGet(string? returnUrl = null)
        {
            ReturnUrl = returnUrl ?? Url.Content("~/");
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            ReturnUrl = returnUrl ?? Url.Content("~/");

            if (!ModelState.IsValid)
                return Page();

            // Build login request and call your service
            var loginRequest = new LoginRequest
            {
                email = Input.email!.Trim(),
                password = Input.password!
            };

            var userDto = await _userService.GetUserByEmail(loginRequest);

            if (userDto == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return Page();
            }

            // Build claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userDto.Id.ToString()),
                new Claim(ClaimTypes.Name, userDto.Email),
                new Claim(ClaimTypes.Role, userDto.Role ?? "Customer")
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return LocalRedirect(ReturnUrl);
        }
    }
}
