using System.ComponentModel.DataAnnotations.Schema;

namespace CrudTemplateApi.Communication.GuiObjects.Users
{
    public class User : IGuiModel
    {
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? AddDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        
        public IEnumerable<int>? GroupIds { get; set; }
    }
}
