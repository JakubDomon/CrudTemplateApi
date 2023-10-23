namespace BusinessLayer.BusinessObjects.Communication.Requests.Security
{
    public class BlAuthenticateUserRequest : IBlRequest
    {
        public string? Login { get; set; }
        public string? Password { get; set; }
    }
}
