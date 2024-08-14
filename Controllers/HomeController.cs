using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Celsia.Models;
using Celsia.Data;

namespace Celsia.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DataContext _Context;

    public HomeController(ILogger<HomeController> logger , DataContext context)
    {
        _logger = logger;
        _Context = context;
    }

    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("Auth") != "Yes")
        {
            return RedirectToAction("Login", "Login");
        }

        var Email = HttpContext.Session.GetString("Email");
        var user = _Context.UsersAuthentications.FirstOrDefault(u => u.Email == Email);
        ViewBag.UserName = user.UserName;
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login", "Login");
    }




}
