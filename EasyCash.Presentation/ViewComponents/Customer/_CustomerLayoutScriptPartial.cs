using System;
using Microsoft.AspNetCore.Mvc;

namespace EasyCash.Presentation.ViewComponents.Customer;

public class _CustomerLayoutScriptPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
