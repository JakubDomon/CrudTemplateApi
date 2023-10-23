using BusinessLayer.BusinessObjects.Communication;
using BusinessLayer.BusinessObjects.Errors.Errors;
using DataAccessLayer.DbContexts;
using DataAccessLayer.Models;

namespace BusinessLayer.Validators
{
    internal abstract class ValidatorBase<Request, Context> : IValidator<Request, Context>
        where Request : IBlRequest
        where Context : DbContextBase
    {
        public abstract IEnumerable<Error> Validate(Request request, Context context);
        protected Error CreateError(string errorKey) => new(errorKey);
    }
}
