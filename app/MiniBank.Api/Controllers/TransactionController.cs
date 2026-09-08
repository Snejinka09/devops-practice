using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniBank.Core.Entities;
using MiniBank.Core.Services;
using System.Linq;

namespace MiniBank.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/transaction")]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService _transactionService;
        private readonly AccountService _accountService;
        public TransactionController (TransactionService transaction, AccountService accountService)
        {
            _transactionService = transaction;
            _accountService = accountService;
        }

        [HttpGet]
        public List<Transaction> GetAllTransactions()
        {
            var all = _transactionService.GetAllTransactions();
            if (IsAdmin())
            {
                return all;
            }
            return all.Where(x => IsOwnTransaction(x)).ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int Id)
        {
            var transaction = _transactionService.GetById(Id);
            if (transaction == null)
            {
                return NotFound();
            }
            else if (!IsAdmin() && !IsOwnTransaction(transaction))
            {
                return Forbid();
            }
            else
            {
                return Ok(transaction);
            }
        }

        [HttpPost]
        public IActionResult AddTransaction(Transaction transaction)
        {
            var fromAccount = _accountService.GetById(transaction.FromAccountId);
            if (!IsAdmin() && (fromAccount == null || fromAccount.ClientId != GetCurrentClientId()))
            {
                return Forbid();
            }
            _transactionService.AddTransaction(transaction);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateTransaction(Transaction transaction)
        {
            var existing = _transactionService.GetById(transaction.Id);
            if (existing == null)
            {
                return NotFound();
            }
            else if (!IsAdmin() && !IsOwnTransaction(existing))
            {
                return Forbid();
            }
            else
            {
                _transactionService.UpdateTransaction(transaction);
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTransaction(int Id)
        {
            var existing = _transactionService.GetById(Id);
            if (existing == null)
            {
                return NotFound();
            }
            else if (!IsAdmin() && !IsOwnTransaction(existing))
            {
                return Forbid();
            }
            _transactionService.DeleteTransaction(Id);
            return Ok();
        }
        private bool IsOwnTransaction(Transaction t)
        {
            var from = _accountService.GetById(t.FromAccountId);
            var to = _accountService.GetById(t.ToAccountId);
            return (from != null && from.ClientId == GetCurrentClientId()) || (to != null && to.ClientId == GetCurrentClientId());
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
