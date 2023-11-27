using BusinessLayer.BusinessObjects.BusinessObjects.Users;

namespace BusinessLayer.BusinessObjects.BusinessObjects.UserGroups
{
    public class UserGroup : BusinessModelBase
    {
        public IEnumerable<User>? Users { get; set; }
    }
}
