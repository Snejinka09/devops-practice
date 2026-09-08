using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniBank.Core.Entities;
using MiniBank.Core.Services;
using System.Linq;

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
            var all = _accountService.GetAllAccount();
            if (IsAdmin())
            {
                return all;
            }
            return all.Where(x => x.ClientId == GetCurrentClientId()).ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var person = _accountService.GetById(id);
            if (person == null)
            {
                return NotFound();
            }
            else if (!IsAdmin() && person.ClientId != GetCurrentClientId())
            {
                return Forbid();
            }
            else
            {
                return Ok(person);
            }
        }

        [HttpPost]
        public IActionResult AddAccount(Account account)
        {
            if (!IsAdmin())
            {
                account.ClientId = GetCurrentClientId() ?? 0;
            }
            _accountService.AddAccount(account);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateAccount(Account account)
        {
            var existing = _accountService.GetById(account.Id);
            if (existing == null)
            {
                return NotFound();
            }
            else if (!IsAdmin() && existing.ClientId != GetCurrentClientId())
            {
                return Forbid();
            }
            else
            {
                _accountService.UpdateAccount(account);
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAccount(int Id)
        {
            var existing = _accountService.GetById(Id);
            if(existing == null)
            {
                return NotFound();
            }
            else if (!IsAdmin() && existing.ClientId != GetCurrentClientId())
            {
                return Forbid();
            }
            _accountService.DeleteAccount(Id);
            return Ok();
        }
        private int? GetCurrentClientId()
        {
            var claim = User.FindFirst("ClientId")?.Value;
            return string.IsNullOrEmpty(claim) ? null : int.Parse(claim);
        }

        private bool IsAdmin()
        {
            return User.FindFirst(System.Security.Claims.ClaimTypes.Role)?.Value == "Admin";
        }
    }
}
