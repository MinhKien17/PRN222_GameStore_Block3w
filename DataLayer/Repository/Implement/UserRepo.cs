using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;
using DataLayer.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace DataLayer.Repository.Implement
{
    public class UserRepo : IUserRepo
    {
        private readonly GameStoreDbContext _dbContext;
        public UserRepo (GameStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> GetByEmail(string email, string password)
        {
            var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<User> RegisterUserAsync(string email, string password, string? role)
        {
            email = email.Trim();
            role = string.IsNullOrWhiteSpace(role) ? "Customer" : role.Trim();

            var exists = await _dbContext.Users.AsNoTracking().AnyAsync(x => x.Email == email);
            if (exists)
                throw new InvalidOperationException("User already exists.");

            var user = new User
            {
                Email = email,
                Password = password,
                Role = role
            };

            await _dbContext.Users.AddAsync(user);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                throw new InvalidOperationException("Failed to create user. The email may already exist.", dbEx);
            }

            return user;
        }

    }
}
