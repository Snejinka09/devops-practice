using Microsoft.AspNetCore.Identity;
using MiniBank.Core.Entities;
using MiniBank.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Core.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void Register(string login, string password)
        {
            var user = new User { Login = login };
            user.PasswordHash = new PasswordHasher<User>().HashPassword(user, password);
            _userRepository.AddUser(user);
        }
        public User Login(string login, string password)
        {
            User user = _userRepository.GetByLogin(login);
            if (user == null)
            {
                return null;
            }
            PasswordVerificationResult passwordVerification = new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, password);
            if (passwordVerification == PasswordVerificationResult.Success)
            {
                return user;
            }
            return null;
        }
    }
}
