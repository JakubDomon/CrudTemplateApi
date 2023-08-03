using AutoMapper;
using BillWebApi.Database.Models.DatabaseModels.Groups;
using BillWebApi.Database.Models.Models;

namespace BillWebApi.Profiles
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<Group, GroupModel>()
                .ForMember(
                    dest => dest.Users,
                    opt => opt.MapFrom(src => src.Users));

            CreateMap<GroupModel, Group>();
        }
    }
}
