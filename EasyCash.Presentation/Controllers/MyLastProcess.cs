using System;
using EasyCash.Business.Abstract;
using EasyCash.DataAccess.Concrete;
using EasyCash.Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCash.Presentation.Controllers;

public class MyLastProcess : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ICustomerAccountProcessService _customerAccountProcessService;

    public MyLastProcess(UserManager<AppUser> userManager, ICustomerAccountProcessService customerAccountProcessService)
    {
        _userManager = userManager;
        _customerAccountProcessService = customerAccountProcessService;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        var context = new Context();
        int id = context.CustomerAccounts.Where(x => x.AppUserID == user.Id && x.CustomerAccountCurrency == "Türk Lirası").Select(y => y.CustomerAccountID).FirstOrDefault();
        var values = _customerAccountProcessService.TMyLastProcess(id);
        return View(values);
    }
}