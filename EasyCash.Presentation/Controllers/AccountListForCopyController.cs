using System;
using EasyCash.Business.Abstract;
using EasyCash.DataAccess.Concrete;
using EasyCash.Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCash.Presentation.Controllers;

public class AccountListForCopyController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ICustomerAccountService _customerAccountService;

    public AccountListForCopyController(UserManager<AppUser> userManager, ICustomerAccountService customerAccountService)
    {
        _userManager = userManager;
        _customerAccountService = customerAccountService;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        var context = new Context();
        int id = context.CustomerAccounts.Where(x => x.AppUserID == user.Id && x.CustomerAccountCurrency == "Türk Lirası").Select(y => y.CustomerAccountID).FirstOrDefault();
        var values = _customerAccountService.TGetCustomerAccountsList(user.Id);
        return View(values);
    }
}
