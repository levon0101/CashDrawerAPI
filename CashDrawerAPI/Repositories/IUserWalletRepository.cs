using System.Collections.Generic;
using Models;

namespace CashDrawerAPI.Repositories
{
    public interface IUserWalletRepository
    {
        IEnumerable<UserWallet> GetUserWallets(long userId);
        
        void AddWalletToUser(UserWallet userWallet);

        UserWallet GetUserWalletById(long userWalletId);
      
        void SaveChanges();

    }
}