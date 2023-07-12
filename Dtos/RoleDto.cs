using NHNT.Models;

namespace NHNT.Dtos
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }

        public RoleDto(Role role)
        {
            Id = role.Id;
            Name = role.Name;
            Discription = role.Discription;
        }
    }
}