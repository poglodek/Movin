using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movin.Dto.Test;
using Movin.Services.IServices;

namespace Movin.Controllers
{
    [Route("Test")]
    public class TestController : Controller
    {
        private readonly ITestServices _testServices;
        private readonly IHostServices _hostServices;

        public TestController(ITestServices testServices,
            IHostServices hostServices)
        {
            _testServices = testServices;
            _hostServices = hostServices;
        }
        [HttpGet]
        public IActionResult Index([FromQuery]string? options)
        {
            if (options is null)
                options = "All";
            return View(_testServices.GetListDto(options));
        }

        [HttpGet("add")]
        public IActionResult AddTest()
        {
            ViewBag.Hosts = _hostServices.GetHostDtoList();
            return View();
        }
        [HttpPost("add")]
        public IActionResult AddTest(TestDto dto)
        {
            if (_testServices.AddTest(dto))
                return RedirectToAction("Index");
            ViewBag.ErrorMessage = "Model not valid or Test Name Exist";
            return View();


        }
        [HttpGet("{id}")]
        public IActionResult Details([FromRoute]int id)
        {
            return View(_testServices.GetTestDto(id));
        }
        [HttpGet("edit/{id}")]
        public IActionResult Edit([FromRoute] int id)
        {
            throw new NotImplementedException();
        }
        [HttpGet("edit/{id}")]
        public IActionResult Edit([FromRoute] int id,TestDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
