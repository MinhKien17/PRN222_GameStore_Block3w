using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameStore_SE170383_DoanMinhKien.Pages.Account
{
    public class LogoutModel : PageModel
    {
        public async Task OnPostAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            Response.Redirect("/");
        }
    }
}
