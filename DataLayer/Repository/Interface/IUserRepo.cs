using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.Repository.Interface
{
    public interface IUserRepo
    {
        public Task<User?> GetByEmail(string email, string password);
        public Task<User> RegisterUserAsync(string email, string password, string? role);
    }
}
