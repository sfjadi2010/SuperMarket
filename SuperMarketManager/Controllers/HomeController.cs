using Microsoft.AspNetCore.Mvc;

namespace SuperMarketManager.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
