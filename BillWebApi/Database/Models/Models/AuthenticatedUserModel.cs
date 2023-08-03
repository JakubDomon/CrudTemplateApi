namespace BillWebApi.Database.Models.Models
{
    public class AuthenticatedUserModel
    {
        public int Id { get; set;}
        public string Login { get; set;}
        public string Token { get; set;}
    }
}
