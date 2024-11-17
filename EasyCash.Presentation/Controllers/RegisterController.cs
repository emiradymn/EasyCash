using System;
using EasyCash.Dto.Dtos.AppUserDtos;
using EasyCash.Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCash.Presentation.Controllers;

public class RegisterController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public RegisterController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
    {
        if (ModelState.IsValid)
        {
            AppUser appUser = new AppUser()
            {
                UserName = appUserRegisterDto.UserName,
                Email = appUserRegisterDto.EMail,
                Name = appUserRegisterDto.Name,
                Surname = appUserRegisterDto.Surname
            };
            var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "ConfirmMail");
            }
        }
        return View();

    }
}
