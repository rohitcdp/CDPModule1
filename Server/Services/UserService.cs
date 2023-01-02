using CDPModule1.Client.Pages;
using CDPModule1.Server.IRepository;
using CDPModule1.Server.IServices;
using CDPModule1.Server.Repository;
using CDPModule1.Server.Utils;
using CDPModule1.Shared;

namespace CDPModule1.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetById(Guid Id)
        {
            return await _userRepository.GetById(Id);
        }

        public async Task<ResponseModal> UpdateUser(User user)
        {
            try
            {
                return new ResponseModal { Data = await _userRepository.UpdateUser(user), Message = StatusConstant.SUCCESS, StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new ResponseModal { Data = ex.Message, Message = StatusConstant.FAILED, StatusCode = 200 };

            }
        }

        public async Task<ResponseModal> DeleteUser(Guid Id)
        {
            try
            {
                var result = await _userRepository.DeleteUser(Id);
                return new ResponseModal { Data = result ? "Succesfully Deleted" : "Not Deleted !!", Message = StatusConstant.SUCCESS, StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new ResponseModal { Data = ex.Message, Message = StatusConstant.FAILED, StatusCode = 200 };
            }
        }

    }
}
