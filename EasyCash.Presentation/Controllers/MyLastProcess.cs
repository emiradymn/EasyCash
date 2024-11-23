using System;
using Microsoft.AspNetCore.Mvc;

namespace EasyCash.Presentation.Controllers;

public class MyLastProcess : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
