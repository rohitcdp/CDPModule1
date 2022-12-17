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
        public AccountController(IAccountService accountService) { 
            _accountService = accountService;
        }

        [HttpPost]
        [Route("AddUser")]
        [Authorize(Roles = Roles.Admin)]
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

        public void ForgotPassword([FromBody] str)
    }
}