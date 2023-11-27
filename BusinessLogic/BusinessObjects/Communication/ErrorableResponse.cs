using BusinessLayer.BusinessObjects.Communication.Enums;
using BusinessLayer.BusinessObjects.Errors.Errors;

namespace BusinessLayer.BusinessObjects.Communication
{
    public class ErrorableResponse<T>
    {
        public IEnumerable<Error>? Errors { get; set; }
        public ResponseStatus Status { get; set; }
        public T? Response { get; set; }
    }
}
