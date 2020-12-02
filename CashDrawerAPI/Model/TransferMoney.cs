namespace CashDrawerAPI.Model
{
    public class TransferMoney
    {
        public long FromUserWalletId { get; set; }

        public long ToUserWalletId { get; set; }

        public double Amount { get; set; }

    }
}
