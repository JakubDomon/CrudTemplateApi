using BillWebApi.Communication;
using BillWebApi.Communication.User;
using BillWebApi.Converters.SpecificConverters.User;
using Bo = BusinessLayer.BusinessObjects;
using DataAccessLayer.DbContexts;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.BusinessLogic.SpecificBusinessLogics.UserManagement;
using Microsoft.AspNetCore.Authorization;
using BusinessLayer.BusinessObjects.Communication.Objects.User.Add;

namespace BillWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly BillAppContext _context;
        private UserConverter _converter;

        public UserController(BillAppContext context, UserConverter converter)
        {
            _context = context;
            _converter = converter;
        }

        [AllowAnonymous]
        [HttpPost]
        public ErrorableResponse<GuiUserAddResponse> CreateUser(GuiUserAddRequest request)
        {
            BlAddUserRequest blRequest = _converter.ConvertUserAddGuiRequest(request);
            Bo.Communication.ErrorableResponse<BlAddUserResponse> blResponse = new UserAddBusinessLogic(_context).ExecuteLogic(blRequest);

            var guiResponse = new ErrorableResponse<GuiUserAddResponse>()
            {
                Errors = _converter.ConvertErrors(blResponse.Errors),
                Status = (Communication.Enums.ResponseStatus)blResponse.Status,
                Response = _converter.ConvertUserAddBlResponse(blResponse.BlResponse)
            };

            return guiResponse;
        }
    }
}
