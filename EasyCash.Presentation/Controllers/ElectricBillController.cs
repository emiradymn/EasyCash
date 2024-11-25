using System;
using Microsoft.AspNetCore.Mvc;

namespace EasyCash.Presentation.Controllers;

public class ElectricBillController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
