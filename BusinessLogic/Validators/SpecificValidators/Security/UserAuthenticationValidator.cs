using BusinessLayer.BusinessObjects.Communication.Requests.Security;
using BusinessLayer.BusinessObjects.Errors.ErrorCodes;
using BusinessLayer.BusinessObjects.Errors.Errors;
using DataAccessLayer.DbContexts;
using Db = DataAccessLayer.Models.User;

namespace BusinessLayer.Validators.SpecificValidators.Security
{
    internal class UserAuthenticationValidator : ValidatorBase<BlAuthenticateUserRequest, BillAppContext>
    {
        public UserAuthenticationValidator() : base() { }

        public override IEnumerable<Error> Validate(BlAuthenticateUserRequest request, BillAppContext context)
        {
            if (request.Login == null
                || request.Login == "")
            {
                yield return CreateError(UserManagementErrorCodes.UserLoginFailed);
            }

            Db.User? user = context.Users.FirstOrDefault(x => x.Login == request.Login);

            if (user == null)
            {
                yield return CreateError(UserManagementErrorCodes.UserLoginFailed);
            }

            if(user != null)
            {
                if(!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                {
                    CreateError(UserManagementErrorCodes.UserLoginFailed);
                }
            }
        }
    }
}
