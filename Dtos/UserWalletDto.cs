namespace Dtos
{
    public class UserWalletDto
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public long WalletId { get; set; }

        public UserDto User { get; set; }

        public WalletDto Wallet { get; set; }

        public double Balance { get; set; }
    }
}
