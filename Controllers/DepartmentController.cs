using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NHNT.Models;
using NHNT.Services;
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
            var departments = _departmentService.List(page, limit);
            // Console.WriteLine(JsonSerializer.Serialize(departments));
            return View();
        }
    }
}
