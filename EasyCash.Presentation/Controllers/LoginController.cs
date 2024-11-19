using System;
using EasyCash.Entity.Concrete;
using EasyCash.Presentation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCash.Presentation.Controllers;

public class LoginController : Controller
{
    private readonly SignInManager<AppUser> _singInManager;
    private readonly UserManager<AppUser> _userManager;


    public LoginController(SignInManager<AppUser> singInManager, UserManager<AppUser> userManager)
    {
        _singInManager = singInManager;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(LoginViewModel loginViewModel)
    {
        var result = await _singInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, false, true);
        if (result.Succeeded)
        {
            var user = await _userManager.FindByNameAsync(loginViewModel.Username);
            if (user.EmailConfirmed == true)
            {
                return RedirectToAction("Index", "MyProfile");
            }
        }
        return View();
    }
}
