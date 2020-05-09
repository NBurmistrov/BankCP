using System.Collections.Generic;

using BankCP.Models.Cards;
using BankCP.Modules.Implementation;
using BankCP.Modules.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace BankCP.Controllers
{
    [Authorized]
    [Route("[controller]/[action]")]    
    public class DebitCardController : Controller
    {
        private readonly IRepository<DebitCard> debitCardRepository;        
        public DebitCardController(IRepository<DebitCard> debitCardRepository)
        {
            this.debitCardRepository = debitCardRepository;
        }
        public IActionResult List() 
            => View(GetAll());
        public IActionResult Create()
            => View();
        public IActionResult Edit(int id)
            => View(GetById(id));
        public void Delete(int id)
            => debitCardRepository.Delete(GetById(id));
        public void Add(DebitCard card) 
            => debitCardRepository.Add(card);       
        public void Edit(DebitCard card) 
            => debitCardRepository.Update(card);
        public DebitCard GetById(int id) 
            => debitCardRepository.GetById(id);
        public IEnumerable<DebitCard> GetAll() 
            => debitCardRepository.List();                
    }
}