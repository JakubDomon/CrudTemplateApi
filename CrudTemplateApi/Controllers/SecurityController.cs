using BillWebApi.Communication;
using BillWebApi.Communication.Security;
using BillWebApi.Converters.SpecificConverters.Security;
using BusinessLayer.BusinessLogic.SpecificBusinessLogics.Security;
using BusinessLayer.BusinessObjects.Communication.Objects.Security;
using BusinessLayer.BusinessObjects.Communication.Requests.Security;
using DataAccessLayer.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Bo = BusinessLayer.BusinessObjects;

namespace BillWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly BillAppContext _context;
        private SecurityConverter _converter;

        public SecurityController(BillAppContext context, SecurityConverter converter)
        {
            _context = context;
            _converter = converter;
        }

        [HttpPost]
        public ErrorableResponse<GuiUserAuthenticationResponse> AuthenticateUser(GuiUserAuthenticationRequest request)
        {
            BlAuthenticateUserRequest blRequest = _converter.ConvertUserAuthenticationGuiRequest(request);
            Bo.Communication.ErrorableResponse<BlAuthenticateUserResponse> blResponse = new UserAuthenticationBusinessLogic(_context).ExecuteLogic(blRequest);

            var guiResponse = new ErrorableResponse<GuiUserAuthenticationResponse>();

            return guiResponse;
        }
    }
}
