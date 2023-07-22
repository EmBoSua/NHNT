using System;
using System.Collections.Generic;
using System.Linq;
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

        public int Count()
        {
            var count = _departmentRepository.Count();
            return count;
        }
        public Department GetById(int id)
        {
            Department department = _departmentRepository.GetById(id);
            if (department == null)
            {
                throw new DataRuntimeException(StatusNotExist.DEPARTMENT_ID);
            }

            return department;
        }

        public List<DepartmentDto> Search(int pageIndex, int pageSize, DepartmentDto dto)
        {
            List<Department> departments = _departmentRepository.Search(pageIndex, pageSize, dto);
            return departments.Select(d => new DepartmentDto(d)).ToList();
        }

        public Department Confirm(int id, int status)
        {
            Department department = _departmentRepository.GetById(id);
            if (department == null)
            {
                throw new DataRuntimeException(StatusNotExist.DEPARTMENT_ID);
            }

            DepartmentStatus enumStatus = DepartmentStatusHelper.Get(status);
            department.Status = enumStatus;

            _departmentRepository.Update(department);

            return department;
        }
    }
}