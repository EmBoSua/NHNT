using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NHNT.Services;

namespace NHNT.Controllers
{
    public class DepartmentController : ControllerCustom
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService, ILogger<HomeController> logger)
        {
            _logger = logger;
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
    }
}
