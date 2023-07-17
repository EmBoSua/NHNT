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
            DepartmentDto[] result = { };

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
    }
}