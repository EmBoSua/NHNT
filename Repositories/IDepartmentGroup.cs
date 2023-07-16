using NHNT.Models;

namespace NHNT.Repositories
{
    public interface IDepartmentGroup
    {
        DepartmentGroup GetById(int id);
        void Add(DepartmentGroup departmentGroup);
        void Update(DepartmentGroup departmentGroup);
        void Delete(int id);
    }
}