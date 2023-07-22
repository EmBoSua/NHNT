using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NHNT.Models;
using NHNT.Services;
using NHNT.Dtos;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using NHNT.Constants;

namespace NHNT.Controllers
{
    public class DepartmentController : ControllerCustom
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
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

        [HttpGet("[controller]/[action]")]
        public IActionResult Me()
        {
            var user = GetUserPartial();
            var departments = _departmentService.FindByUserId(userId: user.Id);
            return Json(departments);
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
