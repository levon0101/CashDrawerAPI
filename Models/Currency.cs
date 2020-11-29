using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Currency
    {
        public long Id { get; set; }
        
        [Required]
        [MaxLength(3)]
        public string CurrencyCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public IEnumerable<WalletCurrency> WalletCurrencies { get; set; }
    }
}
