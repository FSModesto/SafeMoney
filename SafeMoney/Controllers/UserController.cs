﻿using Application.Interfaces;
using Application.ViewModel.Request;
using Application.ViewModel.Response;
using Microsoft.AspNetCore.Mvc;
using SafeMoneyAPI.Configurations;

namespace SafeMoneyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserHandler _handler;

        public UserController(IUserHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<CreateUserResponse>>> CreateUser(CreateUserRequest request)
        {
            try
            {
                var result = await _handler.CreateUser(request);
                return ResponseSetup.CreateResponse(result);
            }
            catch (Exception ex)
            {
                return ResponseSetup.CreateUnexpectedError(ex);
            }
        }
    }
}
