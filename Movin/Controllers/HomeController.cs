using Microsoft.AspNetCore.Mvc;
using Movin.Models;
using System.Diagnostics;

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