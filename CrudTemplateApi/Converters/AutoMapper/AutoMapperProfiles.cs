using AutoMapper;
using BlErr = BusinessLayer.BusinessObjects.Errors;
using Gui = CrudTemplateApi.Communication;
using Bo = BusinessLayer.BusinessObjects.BusinessObjects;
using Go = CrudTemplateApi.Communication.GuiObjects;
using BCom = BusinessLayer.BusinessObjects.Communication;
using GCom = CrudTemplateApi.Communication;
using BusinessLayer.BusinessObjects.BusinessObjects;
using BusinessLayer.BusinessObjects.Communication.API;

namespace CrudTemplateApi.Converters.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            MapUserObjects();
            MapSecurityObjects();
            MapErrorableResponse();
            MapUserGroups();
        }

        private void MapUserObjects()
        {
            CreateMap<Go.Users.User, Bo.Users.User>()
                .ForMember(dest => dest.Groups, opt => opt.MapFrom(src => CreateBoObjectsList<Bo.UserGroups.UserGroup>(src.GroupIds)));
            CreateMap<Bo.Users.User, Go.Users.User>()
                .ForMember(dest => dest.GroupIds, opt => opt.MapFrom(src => CreateGuiObjectIdList<Bo.UserGroups.UserGroup>(src.Groups)));
        }

        private void MapSecurityObjects()
        {
            CreateMap<Go.Security.UserAuthentication, Bo.Security.Login.LoginRequest>();
            CreateMap<Bo.Security.Login.LoginResponse, Go.Security.AuthenticatedUser>();
        }

        private void MapErrorableResponse()
        {
            CreateMap<BlErr.Errors.Error, Gui.Errors.Error>();
            CreateMap(typeof(ErrorableResponse<>), typeof(GCom.ErrorableResponse<>));
        }

        private void MapUserGroups()
        {
            CreateMap<Go.UserGroups.UserGroup, Bo.UserGroups.UserGroup>()
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => CreateBoObjectsList<Bo.Users.User>(src.UsersIds)));
            CreateMap<Bo.UserGroups.UserGroup, Go.UserGroups.UserGroup>()
                .ForMember(dest => dest.UsersIds, opt => opt.MapFrom(src => CreateGuiObjectIdList<Bo.Users.User>(src.Users)));
        }

        private IEnumerable<T> CreateBoObjectsList<T>(IEnumerable<int>? ids)
            where T : BusinessModelBase, new()
        {
            if (ids == null)
            {
                yield break;
            }

            foreach (int id in ids)
            {
                yield return new T()
                {
                    Id = id,
                };
            }
        }

        private IEnumerable<int> CreateGuiObjectIdList<T>(IEnumerable<T>? objects)
            where T : BusinessModelBase
        {
            if (objects == null)
            {
                yield break;
            }

            foreach (T obj in objects)
            {
                yield return obj.Id ?? throw new ArgumentException();
            }
        }
    }
}
