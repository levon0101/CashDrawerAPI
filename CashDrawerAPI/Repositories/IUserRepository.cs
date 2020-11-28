using System.Collections.Generic;
using Models;

namespace CashDrawerAPI.Repositories
{
    public interface IUserRepository
    {
        User GetUser(long id);
        IEnumerable<User> GetUsers();
        void AddUser(User user);
        void DeleteUser(User user);
        void SaveChanges();
    }
}