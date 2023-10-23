using BillWebApi.Communication.Enums;
using BillWebApi.Communication.Errors;

namespace BillWebApi.Communication
{
    public class ErrorableResponse<T>
        where T : IGuiResponse
    {
        public IEnumerable<Error>? Errors { get; set; }
        public ResponseStatus Status { get; set; }
        public T? Response { get; set; }
    }
}
