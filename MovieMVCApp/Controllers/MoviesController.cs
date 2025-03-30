using Microsoft.AspNetCore.Mvc;

namespace MovieMVCApp.Controllers;

public class MoviesController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}