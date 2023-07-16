using System.Collections;
using System.Collections.Generic;

namespace NHNT.Models
{
    public class DepartmentGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}