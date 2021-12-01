using Microsoft.AspNetCore.Mvc;

namespace Movin.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}