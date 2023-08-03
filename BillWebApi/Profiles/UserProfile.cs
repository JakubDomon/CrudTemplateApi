using AutoMapper;
using BillWebApi.Database.Models.DatabaseModels.Users;
using BillWebApi.Database.Models.Models;

namespace BillWebApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
        }
    }
}
