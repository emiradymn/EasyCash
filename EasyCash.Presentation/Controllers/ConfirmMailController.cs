using System;
using EasyCash.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace EasyCash.Presentation.Controllers;

public class ConfirmMailController : Controller
{
    public IActionResult Index(int id)
    {
        var value = TempData["Mail"];
        ViewBag.v = value;
        return View();
    }

    [HttpPost]
    public IActionResult Index(ConfirmMailViewModel confirmMailViewModel)
    {
        return View();
    }
}
