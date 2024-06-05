using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HomeBudget.MVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace HomeBudget.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult NoAccess()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [Authorize(Roles = "Parent")]
    public IActionResult Budget()
    {
        return View();
    }

    [Authorize(Roles = "Parent")]
    public IActionResult Reports()
    {
        return View();
    }

    [Authorize(Roles = "Parent")]
    public IActionResult Family()
    {
        return View();
    }

    public IActionResult Transactions()
    {
        return View();
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
