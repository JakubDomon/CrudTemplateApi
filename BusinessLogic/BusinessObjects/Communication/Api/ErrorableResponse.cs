using BusinessLayer.BusinessObjects.Communication.API.Enums;
using BusinessLayer.BusinessObjects.Errors.Errors;

namespace BusinessLayer.BusinessObjects.Communication.API
{
    public class ErrorableResponse<T>
    {
        public IEnumerable<Error>? Errors { get; set; }
        public ResponseStatus Status { get; set; }
        public T? Response { get; set; }
    }
}
