using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankCP.Models.Accounts;
using BankCP.Modules.Implementation;
using BankCP.Modules.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankCP.Controllers
{
    [Authorized]
    [Route("[controller]/[action]")]
    public class CreditAccountController : Controller
    {
        private readonly IRepository<CreditAccount> creditAccountRepository;
        public CreditAccountController(IRepository<CreditAccount> creditAccountRepository)
        {
            this.creditAccountRepository = creditAccountRepository;
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
            creditAccountRepository.Delete(GetById(id));
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult Add(CreditAccount account)
        {
            creditAccountRepository.Add(account);
            return RedirectToAction("List");
        }
        [HttpPut]
        public IActionResult Edit(CreditAccount account)
        {
            creditAccountRepository.Update(account);
            return RedirectToAction("List");
        }
        [HttpGet]
        public CreditAccount GetById(int id)
            => creditAccountRepository.GetById(id);
        [HttpGet]
        public IEnumerable<CreditAccount> GetAll()
            => creditAccountRepository.List();
    }
}