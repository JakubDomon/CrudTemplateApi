using BillWebApi.Communication.User;
using BusinessLayer.BusinessObjects.Communication.Objects.User.Add;

namespace BillWebApi.Converters.SpecificConverters.User
{
    public class UserConverter : ConverterBase
    {
        #region UserAdd
        public BlAddUserRequest ConvertUserAddGuiRequest(GuiUserAddRequest request)
        {
            return new BlAddUserRequest()
            {
                Login = request.Login ?? "",
                Name = request.Name ?? "",
                Surname = request.Surname ?? "",
                Email = request.Email ?? "",
                Password = request.Password ?? "",
            };
        }

        public GuiUserAddResponse? ConvertUserAddBlResponse(BlAddUserResponse? response)
        {
            if(response == null)
            {
                return null;
            }

            return new GuiUserAddResponse()
            {
                Id = response.Id,
                Name = response.Name,
                Surname = response.Surname,
                Email = response.Email,
            };
        }
        #endregion

    }
}
