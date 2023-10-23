using BusinessLayer.BusinessObjects.BusinessObjects;
using BusinessLayer.BusinessObjects.Communication;
using BusinessLayer.BusinessObjects.Communication.Enums;
using BusinessLayer.BusinessObjects.Communication.Requests;
using BusinessLayer.BusinessObjects.Errors.Errors;
using BusinessLayer.Validators;
using DataAccessLayer.DbContexts;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer.BusinessLogic.BusinessLogicBases
{
    public abstract class CrudBusinessLogicBase<Request, Response, Context>
        where Request : IBlRequest
        where Response : IBlResponse
        where Context : DbContextBase
    {
        protected Context _context;
        protected IConfigurationRoot _configurationRoot;

        public CrudBusinessLogicBase(Context context)
        {
            _context = context;
            _configurationRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }

        public ErrorableResponse<Response> ExecuteLogic(Request request)
        {
            IEnumerable<Error> errors = Validate(request);

            if (errors.Any())
            {
                return CreateErrorResponse(errors);
            }

            Response? response = (Response?)ExecuteInternalLogic(request);

            if (response == null)
            {
                return CreateErrorResponse(errors);
            }

            return new ErrorableResponse<Response>()
            {
                Errors = null,
                Status = ResponseStatus.Success,
                BlResponse = response
            };
        }

        protected IEnumerable<Error> Validate(Request request)
        {
            return ValidatorFactory.CreateValidator<Request, Context>().Validate(request, _context);
        }

        private ErrorableResponse<Response> CreateErrorResponse(IEnumerable<Error> errors)
        {
            return new ErrorableResponse<Response>()
            {
                Errors = errors,
                Status = ResponseStatus.Failure,
                BlResponse = default
            };
        }

        protected abstract IBlResponse? ExecuteInternalLogic(Request request);
    }
}
