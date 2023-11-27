using AutoMapper;
using Dal = DataAccessLayer.Models;
using Bo = BusinessLayer.BusinessObjects.BusinessObjects;

namespace BusinessLayer.Converters.AutoMapper
{
    internal class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            MapUserObjects();
            MapUserGroupsObjects();
        }

        private void MapUserObjects()
        {
            CreateMap<Bo.Users.User, Dal.Users.User>();
            CreateMap<Dal.Users.User, Bo.Users.User>();
        }

        private void MapUserGroupsObjects()
        {
            CreateMap<Bo.UserGroups.UserGroup, Dal.UserGroups.UserGroup>();
            CreateMap<Dal.UserGroups.UserGroup, Bo.UserGroups.UserGroup>();
        }
    }
}
