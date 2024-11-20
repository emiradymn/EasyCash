using System;
using Microsoft.AspNetCore.Mvc;

namespace EasyCash.Presentation.Controllers;

public class CustomerLayoutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
