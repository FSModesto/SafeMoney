using Application.ViewModel.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace SafeMoneyAPI.Configurations
{
    public static class ResponseSetup
    {
        public static ActionResult<BaseResponse<Y>> CreateResponse<Y>(BaseResponse<Y> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = (int)response.StatusCode
            };
        }

        public static ActionResult CreateUnexpectedError(Exception ex)
        {
            return new ObjectResult(ex.Message)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }
    }
}
