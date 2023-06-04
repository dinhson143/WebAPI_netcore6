using WebAPI.Model.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebAPI.Repository.Constants;

namespace WebAPI.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected ActionResult HandleResult<T>(T result, string action = null)
        {
            if (!result!.Equals(default))
            {
                var response = new ResponseResult<T>
                {
                    Errors = default,
                    Data = result
                };
                switch (action)
                {
                    case StatusRequest.Actions.Add:
                        response.StatusCode = (int)HttpStatusCode.Created;
                        response.Message = StatusRequest.AddSuccess;
                        break;
                    case StatusRequest.Actions.Update:
                        response.StatusCode = (int)HttpStatusCode.NoContent;
                        response.Message = StatusRequest.UpdateSuccess;
                        break;
                    case StatusRequest.Actions.Delete:
                        response.StatusCode = (int)HttpStatusCode.NoContent;
                        response.Message = StatusRequest.DeleteSuccess;
                        break;
                    case StatusRequest.Actions.AddFailed:
                        response.StatusCode = (int)HttpStatusCode.NotModified;
                        response.Message = StatusRequest.AddFailure;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.OK;
                        response.Message = HttpStatusCode.OK.ToString();
                        break;
                }
                return Ok(response);
            }
            return BadRequest(new ResponseResult<T>
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                Message = HttpStatusCode.BadRequest.ToString(),
                Errors = default,
                Data = default
            });
        }
    }
}