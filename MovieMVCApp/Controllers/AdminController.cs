using Microsoft.AspNetCore.Mvc;

namespace MovieMVCApp.Controllers;

public class AdminController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}