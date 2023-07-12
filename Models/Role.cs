using System.Collections.Generic;

namespace NHNT.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}