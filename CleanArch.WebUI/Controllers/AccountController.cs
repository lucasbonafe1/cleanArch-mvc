using CleanArch.Domain.Account;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebUI.Controllers
{
    public class AccountController(IAuthenticate authenticateService) : Controller
    {
        public readonly IAuthenticate _authenticateService = authenticateService;



    }
}
