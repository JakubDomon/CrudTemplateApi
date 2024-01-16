using BusinessLayer.BusinessObjects.Errors.Errors;
using BusinessLayer.BusinessObjects.Errors.ErrorCodes;
using BusinessLayer.BusinessObjects.Communication.API.Enums;
using BusinessLayer.BusinessObjects.Communication.API;
using BusinessLayer.BusinessObjects.Communication.Repository;

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
                    new Error(CommonErrorCodes.ServerError, false),
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
                    new Error(CommonErrorCodes.DatabaseError, false),
                },
                Status = ResponseStatus.Failure,
                Response = default
            };
        }

        protected ErrorableResponse<T> CreateResponseFromOperationResult<T>(OperationResult<T> operationRes)
        {
            return new ErrorableResponse<T>
            {
                Errors = operationRes.Status == BusinessObjects.Communication.Repository.Enums.OperationStatus.Fail
                    ? new List<Error>()
                        {
                            new Error(CommonErrorCodes.DatabaseError, false),
                        }
                    : default,
                Status = operationRes.Status == BusinessObjects.Communication.Repository.Enums.OperationStatus.Success
                    ? ResponseStatus.Success
                    : ResponseStatus.Failure,
                Response = operationRes.Object
            };
        }
    }
}
