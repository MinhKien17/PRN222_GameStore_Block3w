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
    public class UserService :IUserService
    {
        private readonly IUserRepo _userRepo;
        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<UserDTO?> GetUserByEmail(LoginRequest loginRequest)
        {
            var user = await _userRepo.GetByEmail(loginRequest.email, loginRequest.password);
            if (user == null) { return null; }
            else return new UserDTO { Email = user.Email, Password = user.Password, Id=user.Id, Role = user.Role };
        }

        public async Task<UserDTO> RegisterUser(RegisterRequest registerRequest)
        {
            var user = await _userRepo.RegisterUserAsync(registerRequest.email, registerRequest.confirmPassword, null);
            if (user == null)
            {
                return null;
            }
            else return new UserDTO { Email = user.Email, Password = user.Password, Id = user.Id, Role = user.Role };
        }
    }
}
