using System.Collections.Generic;

using BankCP.Models.Accounts;
using BankCP.Modules.Implementation;
using BankCP.Modules.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace BankCP.Controllers
{
    [Authorized]
    [Route("[controller]/[action]")]
    public class DebitAccountController : Controller
    {
        private readonly IRepository<DebitAccount> debitAccountRepository;
        public DebitAccountController(IRepository<DebitAccount> debitAccountRepository)
        {
            this.debitAccountRepository = debitAccountRepository;
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
            debitAccountRepository.Delete(GetById(id));
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult Add(DebitAccount account)
        {
            debitAccountRepository.Add(account);
            return RedirectToAction("List");
        }
        [HttpPut]
        public IActionResult Edit(DebitAccount account)
        {
            debitAccountRepository.Update(account);
            return RedirectToAction("List");
        }
        [HttpGet]
        public DebitAccount GetById(int id)
            => debitAccountRepository.GetById(id);
        [HttpGet]
        public IEnumerable<DebitAccount> GetAll()
            => debitAccountRepository.List();
    }
}