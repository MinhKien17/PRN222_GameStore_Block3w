using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repository.Implement
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly GameStoreDbContext _dbContext;
        public CategoryRepo(GameStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Category>> GetAllAsync(string? search)
        {
            var query = _dbContext.Categories.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(g => g.Name.Contains(search));
            }

            return await query.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(g => g.Id == id);
        }
    }
}
