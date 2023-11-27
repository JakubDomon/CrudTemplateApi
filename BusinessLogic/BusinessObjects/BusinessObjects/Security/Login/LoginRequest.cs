namespace BusinessLayer.BusinessObjects.BusinessObjects.Security.Login
{
    public class LoginRequest : BusinessModelBase
    {
        public string? Login { get; set; }
        public string? Password { get; set; }
    }
}
