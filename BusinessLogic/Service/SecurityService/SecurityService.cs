using BusinessLayer.BusinessLogic.Security;
using BusinessLayer.BusinessObjects.BusinessObjects.Security.Login;
using BusinessLayer.BusinessObjects.BusinessObjects.Users;
using BusinessLayer.BusinessObjects.Communication;
using BusinessLayer.Service.AuthService;

namespace BusinessLayer.Service.SecurityService
{
    public class SecurityService : ISecurityService
    {
        ISecurityBusinessLogic SecurityBusinessLogic { get; }

        public SecurityService(ISecurityBusinessLogic securityBusinessLogic)
        {
            SecurityBusinessLogic = securityBusinessLogic;
        }

        public ErrorableResponse<User> DeleteUser(User user) => SecurityBusinessLogic.DeleteUser(user);

        public ErrorableResponse<LoginResponse> LoginUser(LoginRequest userLoginRequest) => SecurityBusinessLogic.LoginUser(userLoginRequest);

        public ErrorableResponse<User> RegisterUser(User user) => SecurityBusinessLogic.RegisterUser(user);

        public ErrorableResponse<User> UpdateUser(User user) => SecurityBusinessLogic.UpdateUser(user);
    }
}
