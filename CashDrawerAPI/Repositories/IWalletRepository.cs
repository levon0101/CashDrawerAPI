using System.Collections.Generic;
using Models;

namespace CashDrawerAPI.Repositories
{
    public interface IWalletRepository
    {
        IEnumerable<Wallet> GetAllWallets();
        Wallet GetWalletById(long id);
        void AddWallet(Wallet wallet);
        void DeleteWallet(Wallet wallet);
        void SaveChanges();
    }
}