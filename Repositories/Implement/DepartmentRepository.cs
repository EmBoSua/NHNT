using System.Linq;
using NHNT.Constants.Statuses;
using NHNT.EF;
using NHNT.Exceptions;
using NHNT.Models;

namespace NHNT.Repositories.Implement
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DbContextConfig _context;

        public DepartmentRepository(DbContextConfig context)
        {
            _context = context;
        }

        public Department GetById(int id)
        {
            return _context.Departments.SingleOrDefault(d => d.Id == id);
        }

        public void Add(Department department)
        {
            if (department == null)
            {
                throw new DataRuntimeException(StatusWrongFormat.DEPARTMENT_IS_NULL);
            }

            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public void Update(Department department)
        {
            if (department == null)
            {
                throw new DataRuntimeException(StatusWrongFormat.DEPARTMENT_IS_NULL);
            }

            _context.Departments.Update(department);
            _context.SaveChanges();
        }
        
        public void Delete(int id)
        {
            Department department = this.GetById(id);
            if (department == null)
            {
                throw new DataRuntimeException(StatusNotExist.DEPARTMENT_ID);
            }

            _context.Departments.Remove(department);
            _context.SaveChanges();
        }
    }
}