using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Core.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public bool IsSavings { get; set; }
        public decimal Balance { get; set; }
        public int ClientId { get; set; }
    }
}
