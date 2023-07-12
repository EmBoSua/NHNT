
using NHNT.Models;

namespace NHNT.Repositories
{
    public interface IUserRepository
    {
        User GetById(int id);
        User GetByUsername(string username);
        User GetByUsernameAndPassowrd(string username, string password);
        void Add(User user);
        void Update(User user);
    }
}