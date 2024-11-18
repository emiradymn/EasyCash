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
            Random random = new Random();
            AppUser appUser = new AppUser()
            {
                UserName = appUserRegisterDto.Username,
                Email = appUserRegisterDto.Email,
                Name = appUserRegisterDto.Name,
                Surname = appUserRegisterDto.Surname,
                District = "aaa",
                City = "bbb",
                ImageUrl = "ccc",
                ConfirmCode = random.Next(1000000, 10000000)
            };
            var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "ConfirmMail");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
        }
        return View();

    }
}
