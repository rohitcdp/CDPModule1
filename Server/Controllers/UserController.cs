using CDPModule1.Server.IServices;
using CDPModule1.Shared;
using CDPModule1.Shared.RequestModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CDPModule1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("GetById")]
        [Authorize]
        public async Task<User> GetById(Guid Id)
        {
            return await _userService.GetById(Id);
        }

        [HttpPost]
        [Route("UpdateUser")]
        [Authorize]
        public async Task<ResponseModal> UpdateUser(UserModal userReq)
        {
            User user = new User
            {
                Id = userReq.Id,
                Name = userReq.Name,
                Email = userReq.Email,
                Address = userReq.Address,
                Country = userReq.Country,
                DOB = userReq.DOB,
                Gender = userReq.Gender,
                IsDeleted = userReq.IsDeleted,
                IsEmailVerified = userReq.IsEmailVerified,
                TenantId = userReq.TenantId,
                Password = userReq.Password,
                UserType = userReq.UserType,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                Tenant = null,
            };
            return await _userService.UpdateUser(user);
        }

        [HttpPost]
        [Route("DeleteUser")]
        [Authorize]
        public async Task<ResponseModal> DeleteUser([FromBody]Guid Id)
        {
            return await _userService.DeleteUser(Id);
        }
    }
}
