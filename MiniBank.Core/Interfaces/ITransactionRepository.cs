using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniBank.Core.Entities;

namespace MiniBank.Core.Interfaces
{
    public interface ITransactionRepository
    {
        Transaction GetById(int Id);
        List<Transaction> GetAllTransactions ();
        void AddTransaction (Transaction transaction);
        void UpdateTransaction (Transaction transaction);
        void DeleteTransaction (int Id);
    }   
}
