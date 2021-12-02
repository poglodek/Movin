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

        public IActionResult Index([FromQuery]string? options)
        {
            if (options is null)
                options = "All";
            return View(_testServices.GetListDto(options));
        }
        [HttpGet("{id}")]
        public IActionResult Details([FromRoute]int id)
        {
            throw new NotImplementedException();
        }
        [HttpGet("{id}")]
        public IActionResult Edit([FromRoute] int id)
        {
            throw new NotImplementedException();
        }
    }
}
