using DataAccessLayer.Models.UserGroups;
using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Models.Users
{
    public class User : IdentityUser<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? AddDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public IEnumerable<UserGroup> Groups { get; set; }
    }
}
