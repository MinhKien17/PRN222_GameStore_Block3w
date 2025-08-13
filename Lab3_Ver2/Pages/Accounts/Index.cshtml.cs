using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLayer.Models;
using Microsoft.AspNetCore.Authorization;

namespace GameStore_SE170383_DoanMinhKien.Pages.Accounts
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly DataLayer.Models.GameStoreDbContext _context;

        public IndexModel(DataLayer.Models.GameStoreDbContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            User = await _context.Users.ToListAsync();
        }
    }
}
