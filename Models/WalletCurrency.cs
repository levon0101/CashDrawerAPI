using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class WalletCurrency
    {
        public long Id { get; set; }

        public long CurrencyId { get; set; }

        public long WalletId { get; set; }

        [Required]
        public Currency Currency { get; set; }

        [Required]
        public Wallet Wallet { get; set; }

        [Required]
        public double Balance { get; set; }
    }
}
