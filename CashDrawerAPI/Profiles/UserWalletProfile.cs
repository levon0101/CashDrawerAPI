using AutoMapper;

namespace CashDrawerAPI.Profiles
{
    public class UserWalletProfile : Profile
    {
        public UserWalletProfile()
        {
            CreateMap<Models.UserWallet, Dtos.UserWalletDto>();
            CreateMap<Dtos.UserWalletDto, Models.UserWallet>();
        }
    }
}
