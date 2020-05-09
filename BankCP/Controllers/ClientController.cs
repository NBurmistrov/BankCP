using System.Collections.Generic;

using BankCP.Models.Users;
using BankCP.Modules.Implementation;
using BankCP.Modules.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace BankCP.Controllers
{
    [Authorized]
    [Route("[controller]/[action]")]
    public class ClientController : Controller
    {
        private readonly IRepository<Client> clientRepository;
        public ClientController(IRepository<Client> clientRepository)
        {
            this.clientRepository = clientRepository;
        }
        [HttpGet]
        public IActionResult List()
            => View(GetAll());
        [HttpGet]
        public IActionResult Create()
            => View();
        [HttpGet]
        public IActionResult Edit(int id)
            => View(GetById(id));
        [HttpGet]
        public IActionResult Delete(int id)
        {
            clientRepository.Delete(GetById(id));
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult Add(Client client)
        {
            clientRepository.Add(client);
            return RedirectToAction("List");
        }
        [HttpPost]
        public IActionResult Edit(Client client)
        {
            clientRepository.Update(client);
            return RedirectToAction("List");
        }
        [HttpGet]
        public Client GetById(int id)
            => clientRepository.GetById(id);
        [HttpGet]
        public IEnumerable<Client> GetAll()
            => clientRepository.List();
    }
}