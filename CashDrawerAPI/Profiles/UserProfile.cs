using AutoMapper;

namespace CashDrawerAPI.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<Models.User, Dtos.UserDto>();
            CreateMap<Dtos.UserDto, Models.User>();
        }
    }
}
