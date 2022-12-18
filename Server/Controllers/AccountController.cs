using CDPModule1.Server.IServices;
using CDPModule1.Server.Utils;
using CDPModule1.Shared;
using CDPModule1.Shared.RequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CDPModule1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("AddUser")]
        [Authorize(Roles = Roles.Admin)]
        [Authorize(Roles = Roles.User)]
        public ResponseModal CreateUser([FromBody] User user)
        {

            return _accountService.CreateUser(user).Result;
        }

        [HttpPost]
        [Route("AddTenant")]
        [Authorize(Roles = Roles.Admin)]
        public ResponseModal CreateTenant([FromBody] Tenant tenant)
        {
            return _accountService.CreateTenant(tenant).Result;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public ResponseModal Login([FromBody] AccountModal loginReq)
        {
            string result = _accountService.Login(loginReq).Result;
            if (result.Equals(StatusConstant.USER_NOT_EXISTS) || result.Equals(StatusConstant.INVALID_PASSWORD))
            {
                return new ResponseModal { Data = null, Message = result, StatusCode = 200 };
            }
            else
            {
                return new ResponseModal { Data = result, Message = StatusConstant.SUCCESS, StatusCode = 200 };
            }
        }

        [HttpPost]
        [Route("SendPasswordlink")]
        [AllowAnonymous]
        public async Task<ResponseModal> ForgotPassword([FromBody] ForgotPassword forgotPassword)
        {
          return  await _accountService.SendForgotPasswordMail(forgotPassword.Email);
        }

        [HttpPost]
        [Route("ChangePassword")]
        [AllowAnonymous]
        public async Task<ResponseModal> ChangePassword([FromBody] ForgotPassword forgotPassword)
        {
            return await _accountService.ChangePassword(forgotPassword.Email, forgotPassword.Password);
        }

        [HttpPost]
        [Route("SendEmailverifiedlink")]
        [Authorize(Roles = Roles.Admin)]
        [Authorize(Roles = Roles.User)]
        public async Task<ResponseModal> SendEmailverifiedlink([FromQuery] string email) =>  await _accountService.SendForgotPasswordMail(email);


        [HttpPost]
        [Route("ChangeEmailVerfiedStatus")]
        [Authorize(Roles = Roles.Admin)]
        [Authorize(Roles = Roles.User)]
        public async Task<ResponseModal> ChangeEmailVerfiedStatus([FromQuery] string email) => await _accountService.ChangeEmailVerifiedStatus(email);


        [HttpGet]
        [Route("GetAllUsers")]
        [Authorize(Roles = Roles.Admin)]
        [Authorize(Roles = Roles.User)]
        public ResponseModal GetAllUsers() => _accountService.GetAllUsers().Result;

        [HttpGet]
        [Route("GetTenantUsers")]
        [Authorize(Roles = Roles.Admin)]
        [Authorize(Roles = Roles.User)]
        public ResponseModal GetTenantUsers(Guid tenantId) => _accountService.GetTenantUsers(tenantId).Result;

    }
}