using BusinessLayer.BusinessObjects.Errors.Resources;
using BusinessLayer.Helpers.Resources;

namespace BusinessLayer.BusinessObjects.Errors.Errors
{
    public abstract class ErrorBase : IError
    {
        public string _message { get; }
        string IError.Message { get => _message; }

        public ErrorBase(string errorCode, bool isCustom)
        {
            if (isCustom)
            {
                _message = errorCode;
            }
            else
            {
                ResourceHelper<ErrorData> resourceHelper = new();
                _message = resourceHelper.GetValue(errorCode) ?? throw new ArgumentException("Invalid error key argument", nameof(errorCode));
            }
        }
    }
}
