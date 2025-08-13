using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameStore_SE170383_DoanMinhKien.Pages.Auth
{
    public class AccessDeniedModel : PageModel
    {
        public bool IsAuthenticated { get; private set; }
        public string Email { get; private set; } = "";
        public string Role { get; private set; } = "";

        public void OnGet()
        {
            IsAuthenticated = User?.Identity?.IsAuthenticated ?? false;
            if (IsAuthenticated)
            {
                Email = User.Identity?.Name ?? "";
                Role = User.FindFirst(ClaimTypes.Role)?.Value ?? "";
            }
        }
    }
}
