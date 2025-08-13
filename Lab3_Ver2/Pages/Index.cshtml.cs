using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lab3_Ver2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DataLayer.Models.GameStoreDbContext _context;

        public IndexModel(DataLayer.Models.GameStoreDbContext context)
        {
            _context = context;
        }

        public IList<Game> Game { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Game = await _context.Games
                .Include(g => g.Category).ToListAsync();
        }
    }
}
