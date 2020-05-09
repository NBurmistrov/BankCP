using BankCP.Modules.Implementation;

using Microsoft.AspNetCore.Mvc;

namespace BankCP.Controllers
{
    [Authorized]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}