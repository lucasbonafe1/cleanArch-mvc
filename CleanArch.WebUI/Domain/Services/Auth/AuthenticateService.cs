﻿using CleanArch.Domain.Account;
using CleanArch.Infra.Data.Identity;
using CleanArch.WebUI.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CleanArch.WebUI.Domain.Services.Auth;

public class AuthenticateService : IAuthenticate
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AuthenticateService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<bool> Authenticate(string email, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);

        return result.Succeeded;
    }

    public async Task<bool> RegisterUser(string email, string password)
    {
        var appUser = new ApplicationUser
        {
            UserName = email,
            Email = email
        };

        var result = _userManager.CreateAsync(appUser, password).Result;

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(appUser, isPersistent: false);
        }

        return result.Succeeded;
    }

    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }
}
