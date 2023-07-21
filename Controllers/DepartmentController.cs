using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NHNT.Constants;
using NHNT.Dtos;
using NHNT.Services;

namespace NHNT.Controllers
{
    public class DepartmentController : ControllerCustom
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService, ILogger<HomeController> logger)
        {
            _departmentService = departmentService;
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

        [HttpPost("[controller]/[action]")]
        public IActionResult Page([FromForm] int page, [FromForm] int limit)
        {
            return Ok(_departmentService.List(page, limit));
        }

        [HttpGet("[controller]/[action]")]
        public IActionResult AdminReview()
        {
            return View();
        }

        [Authorize(RoleConfig.ADMIN)]
        [HttpPost("[controller]/[action]")]
        public IActionResult AdminSearchReview([FromForm] int pageIndex, [FromForm] int pageSize, [FromForm] DepartmentDto dto)
        {
            return Ok(_departmentService.Search(pageIndex, pageSize, dto));
        }

        [Authorize(RoleConfig.ADMIN)]
        [HttpPost("[controller]/[action]")]
        public IActionResult Confirm([FromForm] int id, [FromForm] int status)
        {
            return Ok(new DepartmentDto(_departmentService.Confirm(id, status)));
        }
    }
}
