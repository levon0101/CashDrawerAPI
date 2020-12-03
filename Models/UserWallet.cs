using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class UserWallet
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public long WalletId { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public Wallet Wallet { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Balance { get; set; }
    }
}
