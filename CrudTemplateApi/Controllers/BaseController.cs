using BusinessLayer.BusinessObjects.Communication.API;
using BusinessLayer.BusinessObjects.Communication.API.Enums;
using CrudTemplateApi.Communication.GuiObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudTemplateApi.Controllers
{
    public class BaseController: ControllerBase
    {
        protected private IResult CreateHttpResponse<T>(ErrorableResponse<T> response)
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
