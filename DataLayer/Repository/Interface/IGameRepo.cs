using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.Repository.Interface
{
    public interface IGameRepo
    {
        public Task<List<Game>> GetAllAsync(string? search);
        public Task<Game?> GetByIdAsync(int id);
    }
}
