using BusinessLayer.BusinessObjects.Communication.Enums;
using BusinessLayer.BusinessObjects.Communication;
using BusinessLayer.BusinessObjects.Errors.Errors;
using System.Net;
using BusinessLayer.BusinessObjects.Errors.ErrorCodes;

namespace BusinessLayer.BusinessLogic
{
    internal abstract class BusinessLogicBase
    {
        protected ErrorableResponse<T> CreateSuccessResponse<T>(T Item)
        {
            return new ErrorableResponse<T>
            {
                Errors = null,
                Status = ResponseStatus.Success,
                Response = Item
            };
        }

        protected ErrorableResponse<T> CreateSuccessEmptyResponse<T>()
        {
            return new ErrorableResponse<T>
            {
                Errors = null,
                Status = ResponseStatus.Success,
                Response = default
            };
        }

        protected ErrorableResponse<T> CreateErrorResponse<T>(IEnumerable<Error> errors)
        {
            return new ErrorableResponse<T>()
            {
                Errors = errors,
                Status = ResponseStatus.Failure,
                Response = default
            };
        }

        protected ErrorableResponse<T> CreateErrorResponseException<T>()
        {
            return new ErrorableResponse<T>
            {
                Errors = new List<Error>()
                {
                    new Error(CommonErrorCodes.ServerError),
                },
                Status = ResponseStatus.Failure,
                Response = default
            };
        }

        protected ErrorableResponse<T> CreateDatabaseErrorResponse<T>()
        {
            return new ErrorableResponse<T>
            {
                Errors = new List<Error>()
                {
                    new Error(CommonErrorCodes.DatabaseError),
                },
                Status = ResponseStatus.Failure,
                Response = default
            };
        }
    }
}
