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
    public class FixedDepositController : Controller
    {
        private readonly IRepository<FixedDeposit> fixedDepositRepository;
        public FixedDepositController(IRepository<FixedDeposit> fixedDepositRepository)
        {
            this.fixedDepositRepository = fixedDepositRepository;
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
            fixedDepositRepository.Delete(GetById(id));
            return RedirectToAction("List");
        }
        [HttpPost]
        public IActionResult Add(FixedDeposit deposit)
        {
            fixedDepositRepository.Add(deposit);
            return RedirectToAction("List");
        }
        [HttpPut]
        public IActionResult Edit(FixedDeposit deposit)
        {
            fixedDepositRepository.Update(deposit);
            return RedirectToAction("List");
        }
        [HttpGet]
        public FixedDeposit GetById(int id)
            => fixedDepositRepository.GetById(id);
        [HttpGet]
        public IEnumerable<FixedDeposit> GetAll()
            => fixedDepositRepository.List();
    }
}