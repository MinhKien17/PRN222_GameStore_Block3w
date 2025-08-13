using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTO;
using BusinessLayer.Service.Interface;
using DataLayer.Models;
using DataLayer.Repository.Interface;

namespace BusinessLayer.Service.Implement
{
    public class GameServcie : IGameService
    {
        private readonly IGameRepo _gameRepo;
        private readonly ICategoryRepo _categoryRepo;
        public GameServcie(IGameRepo gameRepo, ICategoryRepo categoryRepo)
        {
            _gameRepo = gameRepo;
            _categoryRepo = categoryRepo;
        }

        public async Task<List<GameDTO>> GetAllAsync(string? search)
        {
            var games = await _gameRepo.GetAllAsync(search);
            var categories = await _categoryRepo.GetAllAsync(null);

            var gameDTOs = games.Select(g =>
            {
                var category = categories.FirstOrDefault(c => c.Id == g.CategoryId);
                return new GameDTO
                {
                    Id = g.Id,
                    Title = g.Title,
                    Price = g.Price,
                    ReleaseDate = g.ReleaseDate,
                    CategoryId = g.CategoryId,
                    CategoryName = category?.Name
                };
            }).ToList();

            return gameDTOs;
        }

        public async Task<GameDTO?> GetByIdAsync(int id)
        {
            var game = await _gameRepo.GetByIdAsync(id);
            var categories = await _categoryRepo.GetAllAsync(null);

            if (game == null) {
                return null;
            }
            else
            {
                var category = categories.FirstOrDefault(c => c.Id == game.CategoryId);
                return new GameDTO
                {
                    Id = game.Id,
                    Title = game.Title,
                    Price = game.Price,
                    ReleaseDate = game.ReleaseDate,
                    CategoryId = game.CategoryId,
                    CategoryName = category?.Name
                };
            }
        }


    }
}
