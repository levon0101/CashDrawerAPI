using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Wallet
    {
        public long Id { get; set; }
        
        //[Required]
        public User User { get; set; }

        public IEnumerable<WalletCurrency> WalletCurrencies { get; set; }
    }
}
