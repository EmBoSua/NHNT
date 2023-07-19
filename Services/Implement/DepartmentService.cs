using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using NHNT.Constants;
using NHNT.Constants.Statuses;
using NHNT.Dtos;
using NHNT.Exceptions;
using NHNT.Models;
using NHNT.Repositories;
using NHNT.Utils;
using System.Text.Json;

namespace NHNT.Services.Implement
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }


        public DepartmentDto[] List(int page, int limit)
        {
            var departments = _departmentRepository.List(page, limit);
            DepartmentDto[] result = Array.ConvertAll(array: departments, new Converter<Department, DepartmentDto>(ConvertDepartmentDto));
            // Console.WriteLine(JsonSerializer.Serialize(result));
            return result;
        }

        public static DepartmentDto ConvertDepartmentDto(Department department)
        {
            return new DepartmentDto(department);
        }

        public DepartmentDto[] FindByUserId(int userId)
        {
            var departments = _departmentRepository.FindByUserId(userId);

            DepartmentDto[] result = Array.ConvertAll(array: departments, new Converter<Department, DepartmentDto>(ConvertDepartmentDto));

            return result;
        }
    }
}