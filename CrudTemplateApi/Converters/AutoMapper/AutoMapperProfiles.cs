using AutoMapper;
using BlErr = BusinessLayer.BusinessObjects.Errors;
using Gui = CrudTemplateApi.Communication;
using Bo = BusinessLayer.BusinessObjects.BusinessObjects;
using Go = CrudTemplateApi.Communication.GuiObjects;
using BCom = BusinessLayer.BusinessObjects.Communication;
using GCom = CrudTemplateApi.Communication;

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
            CreateMap<Go.Users.User, Bo.Users.User>();
            CreateMap<Bo.Users.User, Go.Users.User>();
        }

        private void MapSecurityObjects()
        {
            CreateMap<Go.Security.UserAuthentication, Bo.Security.Login.LoginRequest>();
            CreateMap<Bo.Security.Login.LoginResponse, Go.Security.AuthenticatedUser>();
        }

        private void MapErrorableResponse()
        {
            CreateMap<BlErr.Errors.Error, Gui.Errors.Error>();
            CreateMap(typeof(BCom.ErrorableResponse<>), typeof(GCom.ErrorableResponse<>));
        }

        private void MapUserGroups()
        {
            CreateMap<Go.UserGroups.UserGroup, Bo.UserGroups.UserGroup>();
            CreateMap<Bo.UserGroups.UserGroup, Go.UserGroups.UserGroup>();
        }
    }
}
