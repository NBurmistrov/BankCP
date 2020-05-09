using System.Collections.Generic;

using BankCP.Models.Cards;
using BankCP.Modules.Implementation;
using BankCP.Modules.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace BankCP.Controllers
{
    [Authorized]
    [Route("[controller]/[action]")]
    public class CreditCardController : Controller
    {
        private readonly IRepository<CreditCard> creditCardRepository;
        public CreditCardController(IRepository<CreditCard> creditCardRepository)
        {
            this.creditCardRepository = creditCardRepository;
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
            creditCardRepository.Delete(GetById(id));
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult Add(CreditCard card)
        {
            creditCardRepository.Add(card);
            return RedirectToAction("List");
        }
        [HttpPut]
        public IActionResult Edit(CreditCard card)
        {
            creditCardRepository.Update(card);
            return RedirectToAction("List");
        }
        [HttpGet]
        public CreditCard GetById(int id)
            => creditCardRepository.GetById(id);
        [HttpGet]
        public IEnumerable<CreditCard> GetAll()
            => creditCardRepository.List();
    }
}