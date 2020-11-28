using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using Models;

namespace CashDrawerAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public User GetUser(int id)
        {
            return _dbContext.Users.SingleOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetUsers()
        {

            return _dbContext.Users.ToList();
        }

        public void AddUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();

        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();

        }

    }
}
