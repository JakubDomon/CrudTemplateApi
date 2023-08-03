using AutoMapper;
using BillWebApi.Database.Models.DatabaseModels.Bills;
using BillWebApi.Database.Models.Models;

namespace BillWebApi.Profiles
{
    public class BillProfile : Profile
    {
        public BillProfile()
        {
            CreateMap<Bill, BillModel>()
                .ForMember(
                    dest => dest.AddedBy,
                    opt => opt.MapFrom(src => src.AddedBy));
        }
    }
}
