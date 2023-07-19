using NHNT.Dtos;
using NHNT.Models;

namespace NHNT.Services
{
    public interface IDepartmentService
    {
        DepartmentDto[] List(int page, int limit);
        Department GetById(int id);

        void register(DepartmentRegisDto departmentDto);
    }
}