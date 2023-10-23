using BusinessLayer.BusinessObjects.Communication.Enums;
using BusinessLayer.BusinessObjects.Errors.Errors;

namespace BusinessLayer.BusinessObjects.Communication
{
    public class ErrorableResponse<T>
        where T : IBlResponse
    {
        public IEnumerable<Error>? Errors { get; set; }
        public ResponseStatus Status { get; set; }
        public T? BlResponse { get; set; }
    }
}
