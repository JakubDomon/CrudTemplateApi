using BusinessLayer.BusinessObjects.Errors.Errors;
using Bo = BusinessLayer.BusinessObjects.BusinessObjects;
using BusinessLayer.BusinessObjects.Errors.ErrorCodes;
using BusinessLayer.BusinessObjects.BusinessObjects.Users;

namespace BusinessLayer.Validators.SpecificValidators.Security
{
    internal class SecurityValidator : ValidatorBase<User>, ISecurityValidator
    {
        public SecurityValidator() { }

        public IEnumerable<Error> ValidateUserRegister(Bo.Users.User user)
        {
            IEnumerable<Error> errors = CheckCompulsoryValsUserRegister(user);

            if (errors.Any())
            {
                foreach(Error error in errors)
                {
                    yield return error;
                }
                yield break;
            }
        }

        public IEnumerable<Error> ValidateUserLogin(Bo.Security.Login.LoginRequest loginRequest)
        {
            if(loginRequest.Login == null || loginRequest.Login == string.Empty)
            {
                yield return CreateError(SecurityErrorCodes.UserLoginRequired);
            }
            if(loginRequest.Password == null || loginRequest.Password == string.Empty)
            {
                yield return CreateError(SecurityErrorCodes.UserPasswordRequired);
            }
        }

        public IEnumerable<Error> ValidateUserLogout()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Error> CheckCompulsoryValsUserRegister(Bo.Users.User user)
        {
            if(user.UserName == null)
            {
                yield return CreateError(SecurityErrorCodes.UserLoginRequired);
            }
            if(user.FirstName == null)
            {
                yield return CreateError(SecurityErrorCodes.UserNameRequired);
            }
            if(user.LastName == null)
            {
                yield return CreateError(SecurityErrorCodes.UserSurnameRequired);
            }
            if(user.Email == null)
            {
                yield return CreateError(SecurityErrorCodes.UserEmailRequired);
            }
            if(user.Password == null)
            {
                yield return CreateError(SecurityErrorCodes.UserPasswordRequired);
            }
        }

        public IEnumerable<Error> ValidateUserUpdate(User user)
        {
            foreach(Error error in ValidateObjectHasAnyPropertyValues(user))
            {
                yield return error;
            }
            
        }

        public IEnumerable<Error> ValidateUserDelete(User user)
        {
            yield break;
        }

        public IEnumerable<Error> ValidateQuery(User user)
        {
            foreach(Error error in ValidateObjectHasAnyPropertyValues(user))
            {
                yield return error;
            }
        }
    }
}
