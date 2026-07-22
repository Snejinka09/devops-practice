using MiniBank.Core.Entities;
using MiniBank.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Core.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private List<User> _user = new List<User>();
        public User GetById(int Id)
        {
            return _user.FirstOrDefault(x => x.Id == Id);
        }
        public User GetByLogin(string login)
        {
            return _user.FirstOrDefault(x => x.Login == login);
        }
        public void AddUser(User user)
        {
            _user.Add(user);
        }
    }
}
