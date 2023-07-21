using System.Collections.Generic;
using NHNT.Dtos;
using NHNT.Models;

namespace NHNT.Repositories
{
    public interface IDepartmentRepository
    {
        Department GetById(int id);
        void Add(Department department);
        void Update(Department department);
        void Delete(int id);
        // pagination department
        Department[] List(int page, int limit);
        List<Department> Search(int pageIndex, int pageSize, DepartmentDto dto);
    }
}