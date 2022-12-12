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
        [Route("Register")]
        [Authorize(Roles ="Admin")]
        public ResponseModal Register([FromBody] AccountModal request)
        {
            Tenant user = new Tenant { Email = request.Email, Name = request.Name, Password = request.Password, UserType = request.UserType };
            string result = _accountService.Register(user);
            if (result.Equals(StatusConstant.USER_EXISTS))
            {
                return new ResponseModal { Data = null, Message = result, StatusCode = 200 };
            }
            else
            {
                return new ResponseModal { Data = result, Message = StatusConstant.SUCCESS, StatusCode = 200 };
            }          
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public ResponseModal Login([FromBody] AccountModal loginReq)
        {
            Tenant user = new Tenant { Email = loginReq.Email, Name = loginReq.Name, Password = loginReq.Password, UserType = loginReq.UserType };
            string result = _accountService.Login(user);
            if (result.Equals(StatusConstant.USER_NOT_EXISTS )|| result.Equals(StatusConstant.INVALID_PASSWORD))
            {
                return new ResponseModal { Data = null, Message = result, StatusCode = 200 };
            }
            else
            {
                return new ResponseModal { Data = result, Message = StatusConstant.SUCCESS, StatusCode = 200 };
            }
        }
    }
}