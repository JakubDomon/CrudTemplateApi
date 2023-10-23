namespace BillWebApi.Communication.Security
{
    public class GuiUserAuthenticationResponse : IGuiResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Token { get; set; }
    }
}
