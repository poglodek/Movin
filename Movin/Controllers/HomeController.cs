using Microsoft.AspNetCore.Mvc;

namespace Movin.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}