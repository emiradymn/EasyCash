using System;
using EasyCash.Business.Abstract;
using EasyCash.DataAccess.Concrete;
using EasyCash.Dto.Dtos.CustomerAccountProcessDtos;
using EasyCash.Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyCash.Presentation.Controllers;

public class SendMoneyController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ICustomerAccountProcessService _customerAccountProcessService;
    public SendMoneyController(UserManager<AppUser> userManager, ICustomerAccountProcessService customerAccountProcessService)
    {
        _userManager = userManager;
        _customerAccountProcessService = customerAccountProcessService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(SendMoneyForCustomerAccountProcessDto sendMoneyForCustomerAccountProcessDto)
    {
        var context = new Context();
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        var receiverAccountNumberID = context.CustomerAccounts
                                    .Where(x => x.CustomerAccountNumber == sendMoneyForCustomerAccountProcessDto.ReceiverAccountNumber)
                                    .Select(y => y.CustomerAccountID).FirstOrDefaultAsync();

        // sendMoneyForCustomerAccountProcessDto.SenderID = user.Id;
        // sendMoneyForCustomerAccountProcessDto.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        // sendMoneyForCustomerAccountProcessDto.ProcessType = "Havale";
        // sendMoneyForCustomerAccountProcessDto.ReceiverID = await receiverAccountNumberID;

        var senderAccountNumberID = context.CustomerAccounts
                                    .Where(x => x.AppUserID == user.Id)
                                    .Where(y => y.CustomerAccountCurrency == "Türk Lirası")
                                    .Select(z => z.CustomerAccountID).FirstOrDefault();

        var values = new CustomerAccountProcess();
        values.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        values.SenderID = senderAccountNumberID;
        values.ProcessType = "Havale";
        values.Amount = sendMoneyForCustomerAccountProcessDto.Amount;
        values.Description = sendMoneyForCustomerAccountProcessDto.Description;

        _customerAccountProcessService.TInsert(values);

        return RedirectToAction("Index", "Deneme");
    }
}
