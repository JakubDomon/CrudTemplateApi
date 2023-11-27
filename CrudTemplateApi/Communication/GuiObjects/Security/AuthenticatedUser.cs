using CrudTemplateApi.Communication.GuiObjects.Users;

namespace CrudTemplateApi.Communication.GuiObjects.Security
{
    public class AuthenticatedUser : IGuiModel
    {
        public User? User { get; set; }
        public string? Token { get; set; }
    }
}
