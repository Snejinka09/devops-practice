using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniBank.Core.Entities;
using MiniBank.Core.Services;
using System.Linq;
using System.Security.Principal;

namespace MiniBank.Api.Controllers
{
    [Authorize]
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
            var all = _clientService.GetAllClients();
            if (IsAdmin())
            {
                return all;
            }
            return all.Where(x => x.Id == GetCurrentClientId()).ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var person = _clientService.GetById(id);
            if (person == null)
            {
                return NotFound();
            }
            else if (!IsAdmin() && person.Id != GetCurrentClientId())
            {
                return Forbid();
            }
            else
            {
                return Ok(person);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void AddClient(Client client)
        {
            _clientService.AddClient(client);
        }

        [HttpPut]
        public IActionResult UpdateClient(Client client)
        {
            var existing = _clientService.GetById(client.Id);
            if (existing == null)
            {
                return NotFound();
            }
            else if (!IsAdmin() && existing.Id != GetCurrentClientId())
            {
                return Forbid();
            }
            else
            {
                _clientService.UpdateClient(client);
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int Id)
        {
            var existing = _clientService.GetById(Id);
            if (existing == null)
            {
                return NotFound();
            }
            else if (!IsAdmin() && existing.Id != GetCurrentClientId())
            {
                return Forbid();
            }
            _clientService.DeleteClient(Id);
            return Ok();
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
