namespace Dtos
{
    public class TransferMoneyDto
    {
        public long FromUserWalletId { get; set; }

        public long ToUserWalletId { get; set; }

        public double Amount { get; set; }

    }
}
