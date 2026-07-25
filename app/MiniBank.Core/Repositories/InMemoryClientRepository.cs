using MiniBank.Core.Entities;
using MiniBank.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Core.Repositories
{

    public class InMemoryClientRepository : IClientRepository
    {
        private List<Client> _clients = new List<Client>();
        public void AddClient(Client client)
        {
            _clients.Add(client);
        }

        public void DeleteClient(int id)
        {
            _clients.Remove(GetById(id));
        }

        public List<Client> GetAllClients()
        {
            return _clients;
        }

        public Client GetById(int id)
        {
            return _clients.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateClient(Client client)
        {
           var index = _clients.FindIndex(x => x.Id == client.Id);
            _clients[index] = client;
        }
    }
}
