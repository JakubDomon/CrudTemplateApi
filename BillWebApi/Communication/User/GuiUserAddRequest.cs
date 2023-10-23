namespace BillWebApi.Communication.User
{
    public class GuiUserAddRequest : IGuiRequest
    {
        public string? Login { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
