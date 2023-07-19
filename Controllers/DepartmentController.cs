using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NHNT.Models;
using NHNT.Services;
using NHNT.Dtos;
using System.Text.Json;

namespace NHNT.Controllers
{
    public class DepartmentController : ControllerCustom
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDepartmentService _departmentService;

        public DepartmentController(ILogger<HomeController> logger, IDepartmentService departmentService)
        {
            _logger = logger;
            _departmentService = departmentService;
        }

        public IActionResult Index(int page, int limit)
        {
            return View();
        }

        public IActionResult MyDepartment()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListDepartment(int page, int limit)
        {
            var departments = _departmentService.List(page, limit);
            var total = _departmentService.Count();

            ListDepartmentDto result = new ListDepartmentDto(departments, total);
            return Json(result);

        }

        [HttpGet("[controller]/[action]/{id}")]
        public IActionResult FindByUser([FromRoute] int id)
        {
            var departments = _departmentService.FindByUserId(id);
            return Json(departments);
        }
    }
}
