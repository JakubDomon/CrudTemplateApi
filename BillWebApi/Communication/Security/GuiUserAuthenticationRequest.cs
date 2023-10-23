namespace BillWebApi.Communication.Security
{
    public class GuiUserAuthenticationRequest : IGuiRequest
    {
        public string? Login { get ; set; }
        public string? Password { get; set; }
    }
}
