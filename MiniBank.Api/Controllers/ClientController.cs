using Microsoft.AspNetCore.Mvc;
using MiniBank.Core.Entities;
using MiniBank.Core.Services;

namespace MiniBank.Api.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;
        public ClientController(ClientService client)
        {
            _clientService = client;
        }

        [HttpGet]
        public List<Client> GetAllClients()
        {
            return _clientService.GetAllClients();
        }
        [HttpGet("{id}")]
        public Client GetById(int Id)
        {
            return _clientService.GetById(Id);
        }

        [HttpPost]
        public void AddClient(Client client)
        {
            _clientService.AddClient(client);
        }

        [HttpPut]
        public void UpdateClient(Client client)
        {
            _clientService.UpdateClient(client);
        }

        [HttpDelete("{id}")]
        public void DeleteClient(int Id)
        {
            _clientService.DeleteClient(Id);
        }
    }
}
