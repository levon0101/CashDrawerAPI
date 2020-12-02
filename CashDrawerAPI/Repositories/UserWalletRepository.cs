using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;

namespace CashDrawerAPI.Repositories
{
    public class UserWalletRepository : IUserWalletRepository
    {
        private readonly AppDbContext _dbContext;

        public UserWalletRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public IEnumerable<UserWallet> GetUserWallets(long userId)
        {
            return _dbContext.UserWallets
                .Include(uw => uw.Wallet)
                .Include(uw => uw.User)
                .Where(uw => uw.UserId == userId)
                .ToList();
        }

        public void AddWalletToUser(UserWallet userWallet)
        {
            if (userWallet == null) throw new ArgumentNullException();

            _dbContext.UserWallets.Add(userWallet);
            _dbContext.SaveChanges();
        }

        public UserWallet GetUserWalletById(long userWalletId)
        {
            return _dbContext.UserWallets
                .Include(uw => uw.Wallet)
                .Include(uw => uw.User)
                .SingleOrDefault(uw => uw.Id == userWalletId);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();

        }


    }
}
