using AutoMapper;
using BusinessLayer.BusinessObjects.BusinessObjects.UserGroups;
using BusinessLayer.Service.CrudService;
using BusinessLayer.Service.SecurityService;
using Gui = CrudTemplateApi.Communication.GuiObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using CrudTemplateApi.Communication;
using CrudTemplateApi.Communication.GuiObjects;
using BillWebApi.Communication.Enums;

namespace CrudTemplateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupsController : ControllerBase
    {
        private ICrudService<UserGroup> CrudService { get; set; }
        private IMapper Mapper { get; set; }

        public UserGroupsController(ICrudService<UserGroup> crudService, IMapper mapper)
        {
            CrudService = crudService;
            Mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public IResult RegisterUser(Gui.UserGroups.UserGroup userGroup)
        {
            ErrorableResponse<Gui.UserGroups.UserGroup> response = Mapper.Map<ErrorableResponse<Gui.UserGroups.UserGroup>>(CrudService.Add(Mapper.Map<UserGroup>(userGroup)));
            return CreateHttpResponse(response);
        }

        private IResult CreateHttpResponse<T>(ErrorableResponse<T> response)
            where T : IGuiModel
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
