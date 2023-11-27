using BusinessLayer.BusinessObjects.BusinessObjects.UserGroups;

namespace BusinessLayer.BusinessObjects.BusinessObjects.Users
{
    public class User : BusinessModelBase
    { 
        public string? Login { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public IEnumerable<UserGroup>? Groups { get; set; }
    }
}
