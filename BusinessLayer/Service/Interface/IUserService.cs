using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTO;

namespace BusinessLayer.Service.Interface
{
    public interface IUserService
    {
        public Task<UserDTO?> GetUserByEmail(LoginRequest loginRequest);
        public Task<UserDTO?> RegisterUser(RegisterRequest registerRequest);
    }
}
