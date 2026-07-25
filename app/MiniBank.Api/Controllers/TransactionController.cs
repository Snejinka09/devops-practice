using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniBank.Core.Entities;
using MiniBank.Core.Services;

namespace MiniBank.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/transaction")]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService _transactionService;
        public TransactionController (TransactionService transaction)
        {
            _transactionService = transaction;
        }

        [HttpGet]
        public List<Transaction> GetAllTransactions()
        {
            return _transactionService.GetAllTransactions();
        }

        [HttpGet("{id}")]
        public Transaction GetById(int Id)
        {
            return _transactionService.GetById(Id);
        }

        [HttpPost]
        public void AddTransaction(Transaction transaction)
        {
            _transactionService.AddTransaction(transaction);
        }

        [HttpPut]
        public void UpdateTransaction(Transaction transaction)
        {
            _transactionService.UpdateTransaction(transaction);
        }

        [HttpDelete("{id}")]
        public void DeleteTransaction(int Id)
        {
            _transactionService.DeleteTransaction(Id);
        }
    }
}
