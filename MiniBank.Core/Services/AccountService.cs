using MiniBank.Core.Entities;
using MiniBank.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Core.Services
{
    public class AccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public Account GetById(int Id)
        {
            return _accountRepository.GetById(Id);
        }
        public List<Account> GetAllAccount()
        {
            return _accountRepository.GetAllAccount();
        }
        public void AddAccount(Account account)
        {
            _accountRepository.AddAccount(account);
        }
        public void UpdateAccount(Account account)
        {
            _accountRepository.UpdateAccount(account);
        }
        public void DeleteAccount(int Id)
        {
            _accountRepository.DeleteAccount(Id);
        }
    }
     
}
