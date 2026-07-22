using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiniBank.Core.Entities;
using MiniBank.Core.Interfaces;

namespace MiniBank.Core.Repositories
{
    public class InMemoryTransactionRepository : ITransactionRepository
    {
        private List<Transaction> _transactions = new List<Transaction>();
        public Transaction GetById(int id)
        {
            return _transactions.FirstOrDefault(x => x.Id == id);
        }
        public List<Transaction> GetAllTransactions()
        {
            return _transactions;
        }
        public void AddTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
        }
        public void DeleteTransaction(int id)
        {
            _transactions.Remove(GetById(id));
        }
        public void UpdateTransaction(Transaction transaction)
        {
            var index = _transactions.FindIndex(x => x.Id == transaction.Id);
            _transactions[index] = transaction;
        }
    }
   
}
