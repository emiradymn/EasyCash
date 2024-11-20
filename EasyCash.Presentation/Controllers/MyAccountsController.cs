using System;
using EasyCash.Dto.Dtos.AppUserDtos;
using EasyCash.Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCash.Presentation.Controllers;

[Authorize]
public class MyAccountsController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public MyAccountsController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IActionResult> IndexAsync()
    {
        var values = await _userManager.FindByNameAsync(User.Identity.Name);
        AppUserEditDto appUserEditDto = new AppUserEditDto();
        appUserEditDto.Name = values.Name;
        appUserEditDto.Surname = values.Surname;
        appUserEditDto.PhoneNumber = values.PhoneNumber;
        appUserEditDto.Email = values.Email;
        appUserEditDto.City = values.City;
        appUserEditDto.District = values.District;
        appUserEditDto.ImageUrl = values.ImageUrl;


        return View(appUserEditDto);
    }
}
