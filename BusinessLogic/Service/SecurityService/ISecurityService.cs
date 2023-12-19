using BusinessLayer.BusinessObjects.BusinessObjects.Security.Login;
using BusinessLayer.BusinessObjects.BusinessObjects.Users;
using BusinessLayer.BusinessObjects.Communication.API;

namespace BusinessLayer.Service.AuthService
{
    public interface ISecurityService
    {
        ErrorableResponse<User> RegisterUser(User user);
        ErrorableResponse<User> UpdateUser(User user);
        ErrorableResponse<User> DeleteUser(User user);
        ErrorableResponse<LoginResponse> LoginUser(LoginRequest userAuth);
    }
}
