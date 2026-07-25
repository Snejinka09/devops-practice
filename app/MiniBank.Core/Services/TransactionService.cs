using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniBank.Core.Entities;
using MiniBank.Core.Interfaces;

namespace MiniBank.Core.Services
{
    public class TransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public Transaction GetById(int Id)
        {
            return _transactionRepository.GetById(Id);
        }
        public List<Transaction> GetAllTransactions()
        {
            return _transactionRepository.GetAllTransactions();
        }
        public void AddTransaction(Transaction transaction)
        {
            _transactionRepository.AddTransaction(transaction);
        }
        public void DeleteTransaction(int Id)
        {
            _transactionRepository.DeleteTransaction(Id);
        }
        public void UpdateTransaction(Transaction transaction)
        {
            _transactionRepository.UpdateTransaction(transaction);
        }

    }

}
