using BusinessLayer.BusinessObjects.BusinessObjects.Security.Login;
using BusinessLayer.BusinessObjects.BusinessObjects.Users;
using BusinessLayer.BusinessObjects.Communication.API;

namespace BusinessLayer.BusinessLogic.Security
{
    public interface ISecurityBusinessLogic
    {
        ErrorableResponse<User> RegisterUser(User user);
        ErrorableResponse<User> UpdateUser(User user);
        ErrorableResponse<User> DeleteUser(User user);
        ErrorableResponse<LoginResponse> LoginUser(LoginRequest loginRequest);
    }
}
