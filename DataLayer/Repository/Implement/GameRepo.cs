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
    public class GameRepo : IGameRepo
    {
        private readonly GameStoreDbContext _dbContext;
        public GameRepo(GameStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Game>> GetAllAsync(string? search)
        {
            var query = _dbContext.Games.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                if (decimal.TryParse(search, out var priceValue))
                {
                    query = query.Where(g => g.Title.Contains(search) || g.Price == priceValue);
                }
                else
                {
                    query = query.Where(g => g.Title.Contains(search));
                }
            }

            return await query.ToListAsync();
        }

        public async Task<Game?> GetByIdAsync(int id)
        {
            return await _dbContext.Games.FirstOrDefaultAsync(g => g.Id == id);
        }

    }
}
