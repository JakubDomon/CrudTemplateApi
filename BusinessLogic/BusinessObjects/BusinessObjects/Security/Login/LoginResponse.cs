using BusinessLayer.BusinessObjects.BusinessObjects.Users;

namespace BusinessLayer.BusinessObjects.BusinessObjects.Security.Login
{
    public class LoginResponse : BusinessModelBase
    {
        public User? User { get; set; }
        public string? Token { get; set; }
    }
}
