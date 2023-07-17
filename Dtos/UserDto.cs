using System.Collections.Generic;
using System.Linq;
using NHNT.Models;

namespace NHNT.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ICollection<RoleDto> Roles { get; set; }

        public UserDto(User user)
        {
            Id = user.Id;
            Username = user.Username;
            Email = user.Email;

            if (user.UserRoles != null && user.UserRoles.Any())
            {
                Roles = new List<RoleDto>();
                foreach (UserRole ur in user.UserRoles)
                {
                    Roles.Add(new RoleDto(ur.Role));
                }
            }
        }
    }
}