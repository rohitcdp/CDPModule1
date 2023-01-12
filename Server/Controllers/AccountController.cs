using CDPModule1.Client.Pages;
using CDPModule1.Server.IServices;
using CDPModule1.Server.Services;
using CDPModule1.Server.Utils;
using CDPModule1.Shared;
using CDPModule1.Shared.RequestModel;
using CDPModule1.Shared.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CDPModule1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly CDPDbContext _dbcontext;
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("AddUser")]
        [Authorize]
        public ResponseModal CreateUser([FromBody] UserModal userReq)
        {
            User user = new User
            {
                Name = userReq.Name,
                Email = userReq.Email,
                Address= userReq.Address,
                Country= userReq.Country,
                DOB= userReq.DOB,
                Gender= userReq.Gender,
                IsDeleted= userReq.IsDeleted,
                IsEmailVerified = userReq.IsEmailVerified,
                TenantId = userReq.TenantId,
                Password= userReq.Password,
                UserType= userReq.UserType,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                Tenant = null,
            };
            return _accountService.CreateUser(user).Result;
        }

        [HttpPost]
        [Route("AddTenant")]
       // [Authorize(Roles = Roles.Admin)]
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
        [Authorize]
        public async Task<ResponseModal> SendEmailverifiedlink([FromQuery] string email) =>  await _accountService.SendForgotPasswordMail(email);


        [HttpPost]
        [Route("ChangeEmailVerfiedStatus")]
        [Authorize]
        public async Task<ResponseModal> ChangeEmailVerfiedStatus([FromQuery] string email) => await _accountService.ChangeEmailVerifiedStatus(email);


        [HttpGet]
        [Route("GetAllUsers")]
        [Authorize]
        public List<User> GetAllUsers() => _accountService.GetAllUsers().Result;

        [HttpGet]
        [Route("GetTenantUsers")]
        [Authorize]
        public ResponseModal GetTenantUsers(Guid tenantId) => _accountService.GetTenantUsers(tenantId).Result;


        [HttpPost]
        [Route("resetpassword")]
        public async Task<bool>UpdateReserpassword(resetpasswordmodel resetmodel )
        {
            var users = _dbcontext.Users.Where(X => X.Id == resetmodel.id).FirstOrDefault();

            if (users != null)
            {
                User user = new User
                {

                    Password = resetmodel.ResetPassword,

                };


                _dbcontext.Users.Update(users);
                return save();
            }
               return true;
        }
        public bool save()
        {
            var saved = _dbcontext.SaveChanges();
            return saved > 0 ? true : false;
        }

    }
}