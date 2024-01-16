using BusinessLayer.BusinessObjects.BusinessObjects.Users;
using BusinessLayer.BusinessObjects.Communication.API;
using BusinessLayer.BusinessObjects.Errors.Errors;
using Microsoft.AspNetCore.Identity;

namespace BusinessLayer.Converters.UserManager
{
    internal static class IdentityResultConverter
    {
        public static ErrorableResponse<T> ConvertResultToErrorableResponse<T>(IdentityResult result, T? item)
        {
            if(result == null)
            {
                return new ErrorableResponse<T>()
                {
                    Status = BusinessObjects.Communication.API.Enums.ResponseStatus.Failure,
                };
            }

            if(result.Succeeded)
            {
                return new ErrorableResponse<T>()
                {
                    Status = BusinessObjects.Communication.API.Enums.ResponseStatus.Success,
                    Response = item,
                };
            }
            else
            {
                return new ErrorableResponse<T>()
                {
                    Status = BusinessObjects.Communication.API.Enums.ResponseStatus.Failure,
                    Errors = ConvertIdentityResultErrors(result.Errors)
                };
            }
        }

        private static IEnumerable<Error>? ConvertIdentityResultErrors(IEnumerable<IdentityError> errors)
        {
            if(errors == null || !errors.Any())
            {
                yield break;
            }

            foreach(var error in errors)
            {
                yield return new Error(error.Description, true);
            }
        }
    }
}
