using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movin.Services.IServices;

namespace Movin.Controllers
{
    [Route("Test")]
    public class TestController : Controller
    {
        private readonly ITestServices _testServices;

        public TestController(ITestServices testServices)
        {
            _testServices = testServices;
        }

        public IActionResult Index([FromQuery]string options)
        {
            return View(_testServices.GetListDto(options));
        }
    }
}
