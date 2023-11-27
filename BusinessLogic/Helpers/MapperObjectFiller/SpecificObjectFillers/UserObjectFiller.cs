using BusinessLayer.BusinessObjects.BusinessObjects.UserGroups;
using BusinessLayer.BusinessObjects.BusinessObjects.Users;
using DataAccessLayer.Repositiories;
using Bo = BusinessLayer.BusinessObjects.BusinessObjects;
using Dal = DataAccessLayer.Models;

namespace BusinessLayer.Helpers.MapperObjectFiller.SpecificObjectFillers
{
    internal class UserObjectFiller : MapperObjectFillerBase<Bo.Users.User, Dal.Users.User>
    {
        private IRepository<Dal.UserGroups.UserGroup> UserGroupRepository { get; set; }

        public UserObjectFiller(IRepository<Dal.UserGroups.UserGroup> userGroupRepository)
        {
            UserGroupRepository = userGroupRepository;
        }

        public override Bo.Users.User Fill(User user)
        {
            if(user.Groups?.Any() ?? false)
            {
                user.Groups = FillUserGroups(user.Groups.Select(g => g.Id ?? throw new ArgumentException()));
            }

            return user;
        }

        private IEnumerable<Bo.UserGroups.UserGroup> FillUserGroups(IEnumerable<int> ids) => Mapper.Map<IEnumerable<Bo.UserGroups.UserGroup>>(UserGroupRepository.GetManyByCondition(x => ids.Contains(x.Id)));
    }
}
