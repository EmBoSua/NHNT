using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NHNT.Dtos;
using NHNT.Services;

namespace NHNT.Controllers
{
    public class DepartmentController : ControllerCustom
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService,
        ILogger<HomeController> logger)
        {
            _logger = logger;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("[controller]/[action]/{id}")]
        public IActionResult Detail([FromRoute] int id)
        {
            return View(_departmentService.GetById(id));
        }

        [HttpGet("[controller]/[action]")]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost("[controller]/[action]")]
        public IActionResult Register([FromForm] DepartmentRegisDto departmentDto)
        {
            try
            {
                _departmentService.register(departmentDto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            // return View("[controller]/action/register");
            return View();
        }


    }
}
