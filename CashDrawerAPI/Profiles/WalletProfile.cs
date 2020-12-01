using AutoMapper;

namespace CashDrawerAPI.Profiles
{
    public class WalletProfile : Profile
    {
        public WalletProfile()
        {
            CreateMap<Models.Wallet, Dtos.WalletDto>();
            CreateMap<Dtos.WalletDto, Models.Wallet>();
        }
    }
}
