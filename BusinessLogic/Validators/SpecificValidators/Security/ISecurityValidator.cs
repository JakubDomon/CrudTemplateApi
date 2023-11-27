using BusinessLayer.BusinessObjects.BusinessObjects.Security.Login;
using BusinessLayer.BusinessObjects.BusinessObjects.Users;
using BusinessLayer.BusinessObjects.Errors.Errors;

namespace BusinessLayer.Validators.SpecificValidators.Security
{
    internal interface ISecurityValidator
    {
        IEnumerable<Error> ValidateUserRegister(User user);
        IEnumerable<Error> ValidateUserLogin(LoginRequest loginRequest);
        IEnumerable<Error> ValidateUserLogout();
        IEnumerable<Error> ValidateUserUpdate(User user);
        IEnumerable<Error> ValidateUserDelete(User user);
        IEnumerable<Error> ValidateQuery(User user);
    }
}
