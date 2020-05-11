using System.Text.RegularExpressions;

using BankCP.Modules.Implementation;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BankCP.Controllers
{
    public class LoginController : Controller
    {
        public LoginController(IConfiguration configuration, DBManager dbManager)
        {
            this.configuration = configuration;
            this.dbManager = dbManager;
        }
        private readonly IConfiguration configuration;
        private readonly DBManager dbManager;
        public static string UserID  { get; private set; }
        public static bool isAuthorized { get; private set; } = false;
        public IActionResult Index() => View();

        [HttpPost]
        public ActionResult Authorize(string userID, string password)
        {
            string cs = new Regex("(User Id)|(Password)").IsMatch(configuration.GetConnectionString("Bank")) ?
                "" :
                configuration.GetConnectionString("Bank") + $"User Id={userID};Password={password};";

            isAuthorized = dbManager.IsConnectionStringAvaliable(cs) ? true : false;

            if (isAuthorized)
            {   
                configuration.GetSection("ConnectionStrings")["Bank"] = cs;
                UserID = userID;
                return RedirectToAction("Index", "Home");
            }
            else
                return RedirectToAction("Error");
        }
    }
}