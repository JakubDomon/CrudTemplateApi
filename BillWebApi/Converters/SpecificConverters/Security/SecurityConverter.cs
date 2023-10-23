using BillWebApi.Communication.Security;
using BusinessLayer.BusinessObjects.Communication.Objects.Security;
using BusinessLayer.BusinessObjects.Communication.Requests.Security;

namespace BillWebApi.Converters.SpecificConverters.Security
{
    public class SecurityConverter : ConverterBase
    {
        #region User Authentication
        public BlAuthenticateUserRequest ConvertUserAuthenticationGuiRequest(GuiUserAuthenticationRequest request)
        {
            return new BlAuthenticateUserRequest()
            {
                Login = request.Login ?? "",
                Password = request.Password ?? "",
            };
        }

        public GuiUserAuthenticationResponse ConvertUserAuthenticationBlResponse(BlAuthenticateUserResponse response)
        {
            return new GuiUserAuthenticationResponse()
            {
                Id = response.Id,
                Name = response.Name,
                Surname = response.Surname,
                Token = response.Token,
            };
        }
        #endregion
    }
}
