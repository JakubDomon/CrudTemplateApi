using Bo = BusinessLayer.BusinessObjects.BusinessObjects;
using Gui = CrudTemplateApi.Communication.GuiObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CrudTemplateApi.Communication;
using BillWebApi.Communication.Enums;
using CrudTemplateApi.Communication.GuiObjects;
using BusinessLayer.Service.AuthService;

namespace CrudTemplateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ISecurityService SecurityService;
        private IMapper Mapper { get; set; }

        public UserController(ISecurityService securityService, IMapper mapper)
        {
            SecurityService = securityService;
            Mapper = mapper;
        }

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public IResult RegisterUser(Gui.Users.User user)
        {
            ErrorableResponse<Gui.Users.User> response = Mapper.Map<ErrorableResponse<Gui.Users.User>>(SecurityService.RegisterUser(Mapper.Map<Bo.Users.User>(user)));
            return CreateHttpResponse(response);
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public IResult LoginUser(Gui.Security.UserAuthentication loginRequest)
        {
            ErrorableResponse<Gui.Security.AuthenticatedUser> response = Mapper.Map<ErrorableResponse<Gui.Security.AuthenticatedUser>>(SecurityService.LoginUser(Mapper.Map<Bo.Security.Login.LoginRequest>(loginRequest)));
            return CreateHttpResponse(response);
        }

        [HttpPut]
        public IResult UpdateUser(Gui.Users.User user)
        {
            ErrorableResponse<Gui.Users.User> response = Mapper.Map<ErrorableResponse<Gui.Users.User>>(SecurityService.UpdateUser(Mapper.Map<Bo.Users.User>(user)));
            return CreateHttpResponse(response);
        }

        [HttpDelete]
        public IResult DeleteUser(Gui.Users.User user)
        {
            ErrorableResponse<Gui.Users.User> response = Mapper.Map<ErrorableResponse<Gui.Users.User>>(SecurityService.DeleteUser(Mapper.Map<Bo.Users.User>(user)));
            return CreateHttpResponse(response);
        }


        private IResult CreateHttpResponse<T>(ErrorableResponse<T> response)
            where T: IGuiModel
        {
            return response.Status switch
            {
                ResponseStatus.Success => Results.Ok(response),
                ResponseStatus.Failure => Results.StatusCode(500),
                _ => Results.StatusCode(500)
            };
        }
    }
}
