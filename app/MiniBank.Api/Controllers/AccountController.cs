using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniBank.Core.Entities;
using MiniBank.Core.Services;

namespace MiniBank.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/accounts")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;
        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public List<Account> GetAllAccount()
        {
            return _accountService.GetAllAccount();
        }

        [HttpGet("{id}")]
        public Account GetById(int id)
        {
            return _accountService.GetById(id);
        }
        [HttpPost]
        public void AddAccount(Account account)
        {
            _accountService.AddAccount(account);
        }

        [HttpPut]
        public void UpdateAccount(Account account)
        {
            _accountService.UpdateAccount(account);
        }

        [HttpDelete("{id}")]
        public void DeleteAccount(int Id)
        {
            _accountService.DeleteAccount(Id);
        }
    }
}
