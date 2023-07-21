using System;
using System.Collections.Generic;
using System.Linq;
using NHNT.Constants;
using NHNT.Constants.Statuses;
using NHNT.Dtos;
using NHNT.Exceptions;
using NHNT.Models;
using NHNT.Repositories;

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
            DepartmentDto[] result = departments.Select(x => new DepartmentDto(x)).ToArray();

            return result;
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