using Microsoft.AspNetCore.Mvc;
using MvcWebApp.Models;

namespace MvcWebApp.Controllers;

public class HelloController : Controller
{
    [HttpGet("hello")]
    public IActionResult Index()
    {
        var model = new GreetingModel
        {
            Message = "Hello from ASP.NET Core MVC"
        };

        ViewData["CurrentTime"] = DateTime.Now;
        return View(model);
    }
}
