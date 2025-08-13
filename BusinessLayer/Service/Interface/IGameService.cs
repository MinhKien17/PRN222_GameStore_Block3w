using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTO;

namespace BusinessLayer.Service.Interface
{
    public interface IGameService
    {
        public Task<List<GameDTO>> GetAllAsync(string? search);
        public Task<GameDTO?> GetByIdAsync(int id);

    }
}
