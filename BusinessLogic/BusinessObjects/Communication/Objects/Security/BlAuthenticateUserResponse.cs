namespace BusinessLayer.BusinessObjects.Communication.Objects.Security
{
    public class BlAuthenticateUserResponse : IBlResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Token { get; set; }
    }
}
