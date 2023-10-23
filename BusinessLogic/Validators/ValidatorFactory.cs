using BusinessLayer.BusinessObjects.Communication;
using BusinessLayer.BusinessObjects.Communication.Objects.User.Add;
using BusinessLayer.BusinessObjects.Communication.Requests.Security;
using BusinessLayer.Validators.SpecificValidators.Security;
using BusinessLayer.Validators.SpecificValidators.User;
using DataAccessLayer.DbContexts;

namespace BusinessLayer.Validators
{
    internal class ValidatorFactory
    {
        public static IValidator<Request, Context> CreateValidator<Request, Context>()
            where Request : IBlRequest
            where Context : DbContextBase
        {
            return typeof(Request) switch
            {
                Type type when type == typeof(BlAddUserRequest) => (IValidator<Request, Context>) new UserAddValidator(),
                Type type when type == typeof(BlAuthenticateUserRequest) => (IValidator<Request, Context>) new UserAuthenticationValidator(),
                _ => throw new ArgumentException()
            };
        }
    }
}
