using DataAccessLayer.Models.UserGroups;

namespace DataAccessLayer.Models.Users
{
    public class User : EntityBase
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<UserGroup> Groups { get; set; }
    }
}
