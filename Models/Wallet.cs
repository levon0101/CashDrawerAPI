using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Wallet
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(3)]
        public string CurrencyCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string CurrencyName { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public IEnumerable<UserWallet> UserWallets { get; set; }
    }
}
