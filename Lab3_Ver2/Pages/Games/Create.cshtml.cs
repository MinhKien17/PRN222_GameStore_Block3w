using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataLayer.Models;
using Microsoft.AspNetCore.Authorization;
using DataLayer.Repository.Interface;

namespace GameStore_SE170383_DoanMinhKien.Pages.Games
{
    [Authorize(Roles = "Staff, Admin")]
    public class CreateModel : PageModel
    {
        private readonly DataLayer.Models.GameStoreDbContext _context;
        private readonly ICategoryRepo _categoryRepo;

        public CreateModel(DataLayer.Models.GameStoreDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Game Game { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                foreach (var kvp in ModelState)
                {
                    foreach (var error in kvp.Value.Errors)
                    {
                        Console.WriteLine($"{kvp.Key}: {error.ErrorMessage}");
                    }
                }
                return Page();
            }

            var category = await _categoryRepo.GetByIdAsync((int)Game.CategoryId);

            Game.Category = category;

            _context.Games.Add(Game);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
