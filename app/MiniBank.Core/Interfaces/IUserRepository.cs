using MiniBank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Core.Interfaces
{
    public interface IUserRepository
    {
        User GetById(int Id);
        User GetByLogin(string login);
        void AddUser(User user);
    }
}
