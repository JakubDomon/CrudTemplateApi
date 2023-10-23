using BusinessLayer.BusinessObjects.Errors.Resources;
using BusinessLayer.Helpers;

namespace BusinessLayer.BusinessObjects.Errors.Errors
{
    public abstract class ErrorBase : IError
    {
        public string Message { get; }

        public ErrorBase(string errorKey)
        {
            ResourceHelper<ErrorData> resourceHelper = new();
            Message = resourceHelper.GetValue(errorKey) ?? throw new ArgumentException("Invalid error key argument", nameof(errorKey));
        }
    }
}
