
using System.Collections.Generic;
using NHNT.Dtos;
using NHNT.Models;

namespace NHNT.Services
{
    public interface IDepartmentService
    {
        DepartmentDto[] List(int page, int limit);
        Department GetById(int id);
        List<DepartmentDto> Search(int pageIndex, int pageSize, DepartmentDto dto);
        Department Confirm(int id, int status);
    }
}