namespace CrudTemplateApi.Communication.GuiObjects.UserGroups
{
    public class UserGroup : IGuiModel
    {
        public int Id { get; set; }
        public IEnumerable<int>? UsersIds { get; set; }
    }
}
