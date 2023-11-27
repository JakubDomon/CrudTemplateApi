using DataAccessLayer.Models.Users;

namespace DataAccessLayer.Models.UserGroups
{
    public class UserGroup : EntityBase
    {
        public IEnumerable<User> Users { get; set; }
    }
}
