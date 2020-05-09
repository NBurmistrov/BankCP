using System;

using BankCP.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BankCP.Modules.Implementation
{
    // Don't recomend to do like this, use just for course project. 
    public class Authorized : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!LoginController.isAuthorized)
                context.Result = new RedirectToActionResult("Index", "Login", null);
        }
    }
}
