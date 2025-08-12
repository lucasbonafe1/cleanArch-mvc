using CleanArch.Domain.Account;
using CleanArch.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebUI.Controllers;

public class AccountController(IAuthenticate authenticateService) : Controller
{
    public readonly IAuthenticate _authenticateService = authenticateService;

    [HttpGet]
    public IActionResult Login(string returnUrl)
    {
        return View(new LoginViewModel()
        {
            ReturnUrl = returnUrl
        });
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        var result = await _authenticateService.Authenticate(model.Email, model.Password);

        if (result)
        {
            if (string.IsNullOrEmpty(model.ReturnUrl))
                return RedirectToAction("Index", "Home");

            return Redirect(model.ReturnUrl);
        }
        else
        {
            ModelState.AddModelError("", "Invalid username or password.");
            return View(model);
        }
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        var result = await _authenticateService.RegisterUser(model.Email, model.Password);

        if (result)
            return Redirect("/");
        else
        {
            ModelState.AddModelError(string.Empty, "Invalid Register Attempt");
            return View(model);
        }
    }

    public async Task<IActionResult> Logout()
    {
        await _authenticateService.Logout();
        return Redirect("/Account/Login");
    }
}
