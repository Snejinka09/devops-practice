using MiniBank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniBank.Core.Entities;

namespace MiniBank.Core.Interfaces
{
    public interface IAccountRepository
    {
        Account GetById(int id);
        List<Account> GetAllAccount();
        void AddAccount(Account account);
        void UpdateAccount(Account account);
        void DeleteAccount(int id);
    }
}
