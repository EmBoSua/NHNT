using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NHNT.Models;

namespace NHNT.Controllers
{
    public class DepartmentController : ControllerCustom
    {
        private readonly ILogger<HomeController> _logger;

        public DepartmentController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
