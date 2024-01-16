using Dal = DataAccessLayer.Models;
using BusinessLayer.BusinessObjects.BusinessObjects.Users;
using BusinessLayer.BusinessObjects.BusinessObjects.Security.Login;
using BusinessLayer.Validators.SpecificValidators.Security;
using AutoMapper;
using Am = BusinessLayer.Converters.AutoMapper;
using BusinessLayer.BusinessObjects.Errors.Errors;
using BusinessLayer.BusinessObjects.Communication.API;
using Microsoft.AspNetCore.Identity;
using BusinessLayer.Converters.UserManager;

namespace BusinessLayer.BusinessLogic.Security
{
    internal class SecurityBusinessLogic : BusinessLogicBase, ISecurityBusinessLogic
    {
        private ISecurityValidator _securityValidator { get; }
        private IMapper _mapper { get; }
        private UserManager<Dal.Users.User> _userManager { get; }

        public SecurityBusinessLogic(ISecurityValidator validator, UserManager<Dal.Users.User> userManager)
        {
            _securityValidator = validator;
            _mapper = Am.AutoMapper.Mapper;
            _userManager = userManager;
        }

        public ErrorableResponse<User> RegisterUser(User user)
        {
            IEnumerable<Error> errors = _securityValidator.ValidateUserRegister(user);
            if (errors.Any())
            {
                return CreateErrorResponse<User>(errors);
            }

            try
            {
                var result = _userManager.CreateAsync(_mapper.Map<Dal.Users.User>(user), user.Password);

                result.Wait();
                return IdentityResultConverter.ConvertResultToErrorableResponse<User>(result.Result, user);
            }
            catch (Exception ex)
            {
                return CreateErrorResponseException<User>();
            }
        }

        public ErrorableResponse<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public ErrorableResponse<User> DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public ErrorableResponse<LoginResponse> LoginUser(LoginRequest userLoginRequest)
        {
            throw new NotImplementedException();
        }
    }
}
