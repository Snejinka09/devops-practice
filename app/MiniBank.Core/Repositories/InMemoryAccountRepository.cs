using MiniBank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniBank.Core.Interfaces;

namespace MiniBank.Core.Repositories
{
    public class InMemoryAccountRepository : IAccountRepository
    {
        private List<Account> _accounts = new List<Account>();
        public Account GetById(int Id)
        {
            return _accounts.FirstOrDefault(a => a.Id == Id);
        }
        public void AddAccount(Account account)
        {
            _accounts.Add(account);
        }
        public void UpdateAccount(Account account)
        {
            var index = _accounts.FindIndex(x => x.Id == account.Id);
            _accounts[index] = account;
        }
        public void DeleteAccount(int id)
        {
            _accounts.Remove(GetById(id));
        }
        public List<Account> GetAllAccount()
        {
            return _accounts;
        }
    }
}
