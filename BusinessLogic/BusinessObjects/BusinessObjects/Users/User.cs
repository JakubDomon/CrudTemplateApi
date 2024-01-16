using BusinessLayer.BusinessObjects.BusinessObjects.UserGroups;
using Microsoft.AspNetCore.Identity;

namespace BusinessLayer.BusinessObjects.BusinessObjects.Users
{
    public class User : IdentityUser<int>, IBusinessModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public DateTime? AddDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public IEnumerable<UserGroup>? Groups { get; set; }
    }
}
