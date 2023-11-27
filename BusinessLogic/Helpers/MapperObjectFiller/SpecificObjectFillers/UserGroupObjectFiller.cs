using Dal = DataAccessLayer.Models;
using Bo = BusinessLayer.BusinessObjects.BusinessObjects;
using DataAccessLayer.Repositiories;

namespace BusinessLayer.Helpers.MapperObjectFiller.SpecificObjectFillers
{
    internal class UserGroupObjectFiller : MapperObjectFillerBase<Bo.UserGroups.UserGroup, Dal.UserGroups.UserGroup>
    {
        private IRepository<Dal.Users.User> UserRepository { get; set; }

        public UserGroupObjectFiller(IRepository<Dal.Users.User> userRepository)
        {
            UserRepository = userRepository;
        }

        public override Bo.UserGroups.UserGroup Fill(Bo.UserGroups.UserGroup group)
        {
            if(group.Users?.Any() ?? false)
            {
                group.Users = FillUsers(group.Users.Select(u => u.Id ?? throw new ArgumentException()));
            }

            return group;
        }

        private IEnumerable<Bo.Users.User> FillUsers(IEnumerable<int> ids) => Mapper.Map<IEnumerable<Bo.Users.User>>(UserRepository.GetManyByCondition(x => ids.Contains(x.Id)));
    }
}
