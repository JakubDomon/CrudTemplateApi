using BillWebApi.Communication.Enums;
using CrudTemplateApi.Communication.Errors;
using CrudTemplateApi.Communication.GuiObjects;

namespace CrudTemplateApi.Communication
{
    public class ErrorableResponse<T>
        where T : IGuiModel
    {
        public IEnumerable<Error>? Errors { get; set; }
        public ResponseStatus Status { get; set; }
        public T? Response { get; set; }
    }
}
