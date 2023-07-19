
using NHNT.Dtos;

namespace NHNT.Services
{
    public interface IDepartmentService
    {
        DepartmentDto[] List(int page, int limit);
        DepartmentDto[] FindByUserId(int userId);
        int Count();
    }
}