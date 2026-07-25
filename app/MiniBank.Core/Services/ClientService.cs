using MiniBank.Core.Entities;
using MiniBank.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Core.Services
{
    public class ClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public Client GetById(int Id)
        {
            return _clientRepository.GetById(Id);
        }
        public List<Client> GetAllClients()
        {
            return _clientRepository.GetAllClients();
        }
        public void AddClient(Client client)
        {
            _clientRepository.AddClient(client);
        }
        public void DeleteClient(int Id)
        {
            _clientRepository.DeleteClient(Id);
        }
        public void UpdateClient(Client client)
        {
            _clientRepository.UpdateClient(client);
        }
    }
}
