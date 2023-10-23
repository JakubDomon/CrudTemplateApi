using BusinessLayer.BusinessObjects.Communication.Objects.User.Add;
using BusinessLayer.BusinessObjects.Communication.Requests;
using BusinessLayer.BusinessObjects.Errors.ErrorCodes;
using BusinessLayer.BusinessObjects.Errors.Errors;
using DataAccessLayer.DbContexts;

namespace BusinessLayer.Validators.SpecificValidators.User
{
    internal class UserAddValidator : ValidatorBase<BlAddUserRequest, BillAppContext>
    {
        public UserAddValidator() : base() { }

        public override IEnumerable<Error> Validate(BlAddUserRequest request, BillAppContext context)
        {
            /// Login
            if (request.Login == null
                || request.Login.Length == 0)
            {

                yield return CreateError(UserManagementErrorCodes.UserLoginRequired);
            }

            if (context.Users.Any(x => x.Login == request.Login))
            {
                yield return CreateError(UserManagementErrorCodes.UserLoginAlreadyExists);
            }

            /// Name
            if (request.Name == null
                || request.Name.Length == 0)
            {
                yield return CreateError(UserManagementErrorCodes.UserNameRequired);
            }
            if (request.Name != null)
            {
                if (request.Name.Length < 2)
                {
                    yield return CreateError(UserManagementErrorCodes.UserNameTooShort);
                }
                if (request.Name.Length > 20)
                {
                    yield return CreateError(UserManagementErrorCodes.UserNameTooLong);
                }
            }

            /// Surname
            if (request.Surname == null
                || request.Surname.Length == 0)
            {
                yield return CreateError(UserManagementErrorCodes.UserSurnameRequired);
            }
            if (request.Surname != null)
            {
                if (request.Surname.Length < 2)
                {
                    yield return CreateError(UserManagementErrorCodes.UserSurnameTooShort);
                }
                if (request.Surname.Length > 20)
                {
                    yield return CreateError(UserManagementErrorCodes.UserSurnameTooLong);
                }
            }

            /// Password
            if (request.Password == null
                || request.Password.Length == 0)
            {
                yield return CreateError(UserManagementErrorCodes.UserPasswordRequired);
            }
            if (request.Password != null)
            {
                if (request.Password.Length < 5)
                {
                    yield return CreateError(UserManagementErrorCodes.UserPasswordTooShort);
                }
                if (!IsPasswordConditionsMet(request.Password))
                {
                    yield return CreateError(UserManagementErrorCodes.UserPasswordRequirementsNotMet);
                }
            }
        }

        private bool IsPasswordConditionsMet(string password)
        {
            return password.Any(x => char.IsLetterOrDigit(x));
        }
    }
}
