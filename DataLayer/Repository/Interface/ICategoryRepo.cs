using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.Repository.Interface
{
    public interface ICategoryRepo
    {
        public Task<List<Category>> GetAllAsync(string? search);
        public Task<Category?> GetByIdAsync(int id);
    }
}
