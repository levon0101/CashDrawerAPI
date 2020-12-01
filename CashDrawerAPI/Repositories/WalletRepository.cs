using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using Models;

namespace CashDrawerAPI.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly AppDbContext _dbContext;

        public WalletRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Wallet> GetAllWallets()
        {
            return _dbContext.Wallets.ToList();
        }

        public Wallet GetWalletById(long id)
        {
            return _dbContext.Wallets.SingleOrDefault(w => w.Id == id);
        }


        public void AddWallet(Wallet wallet)
        {
            if (wallet == null) throw new ArgumentNullException(nameof(wallet));

            _dbContext.Wallets.Add(wallet);
            _dbContext.SaveChanges();
        }

        public void DeleteWallet(Wallet wallet)
        {
            if (wallet == null) throw new ArgumentNullException(nameof(wallet));

            _dbContext.Wallets.Remove(wallet);
            _dbContext.SaveChanges();

        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();

        }
    }
}
