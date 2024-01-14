using Dal = DataAccessLayer.Models;
using DataAccessLayer.Repositiories;
using BusinessLayer.BusinessObjects.Errors.Errors;
using Bo = BusinessLayer.BusinessObjects.BusinessObjects;
using BusinessLayer.BusinessObjects.Errors.ErrorCodes;
using BusinessLayer.BusinessObjects.BusinessObjects.Users;

namespace BusinessLayer.Validators.SpecificValidators.Security
{
    internal class SecurityValidator : ValidatorBase<User>, ISecurityValidator
    {
        private readonly IRepository<Dal.Users.User> Repository;

        public SecurityValidator(IRepository<Dal.Users.User> repository)
        {
            Repository = repository;
        }

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
            if(Repository.GetManyByCondition(x => x.Login == user.Login).Object.Any())
            {
                yield return CreateError(SecurityErrorCodes.UserLoginAlreadyExists);
                yield break;
            }

            if(user.Login == null)
            {
                yield return CreateError(SecurityErrorCodes.UserLoginRequired);
            }
            if(user.Name == null)
            {
                yield return CreateError(SecurityErrorCodes.UserNameRequired);
            }
            if(user.Surname == null)
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
            if(!Repository.GetManyByCondition(x => x.Id == user.Id).Object.Any())
            {
                yield return CreateError(SecurityErrorCodes.UserNotExists);
                yield break;
            }
            foreach(Error error in ValidateObjectHasAnyPropertyValues(user))
            {
                yield return error;
            }
            
        }

        public IEnumerable<Error> ValidateUserDelete(User user)
        {
            if(!Repository.GetManyByCondition(x => x.Id == user.Id).Object.Any())
            {
                yield return CreateError(SecurityErrorCodes.UserNotExists);
            }
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
