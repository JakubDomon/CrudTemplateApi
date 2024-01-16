using Dal = DataAccessLayer.Models;
using Bo = BusinessLayer.BusinessObjects.BusinessObjects;
using DataAccessLayer.Repositiories;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BusinessLayer.Helpers.MapperObjectFiller.SpecificObjectFillers
{
    internal class UserGroupObjectFiller : MapperObjectFillerBase<Bo.UserGroups.UserGroup, Dal.UserGroups.UserGroup>
    {
        private UserManager<Dal.Users.User> _userManager { get; set; }

        public UserGroupObjectFiller(UserManager<Dal.Users.User> userRepository)
        {
            _userManager = userRepository;
        }

        public override Bo.UserGroups.UserGroup Fill(Bo.UserGroups.UserGroup group)
        {
            if(group.Users?.Any() ?? false)
            {
                group.Users = FillUsers(group.Users.Select(u => u.Id));
            }

            return group;
        }

        private IEnumerable<Bo.Users.User> FillUsers(IEnumerable<int> ids) 
        {
            return Mapper.Map<IEnumerable<Bo.Users.User>>(_userManager.Users.Where(u => ids.Contains(u.Id)));
        }
    }
}
