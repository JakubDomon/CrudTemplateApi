using BusinessLayer.BusinessObjects.Communication;
using BusinessLayer.BusinessObjects.Errors.Errors;
using DataAccessLayer.DbContexts;

namespace BusinessLayer.Validators
{
    internal interface IValidator<Request, Context>
        where Request : IBlRequest
        where Context : DbContextBase
    {
        public IEnumerable<Error> Validate(Request request, Context context);
    }
}
