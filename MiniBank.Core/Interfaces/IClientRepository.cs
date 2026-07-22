using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniBank.Core.Entities;

namespace MiniBank.Core.Interfaces
{
    public interface IClientRepository
    {
        Client GetById (int id);
        List<Client> GetAllClients();
        void AddClient (Client client);
        void UpdateClient (Client client);
        void DeleteClient (int id);
    }
}
