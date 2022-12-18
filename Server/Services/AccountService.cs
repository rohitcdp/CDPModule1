using CDPModule1.Server.Authentication;
using CDPModule1.Server.IRepository;
using CDPModule1.Server.IServices;
using CDPModule1.Server.Repository;
using CDPModule1.Server.Utils;
using CDPModule1.Shared;
using CDPModule1.Shared.RequestModel;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CDPModule1.Server.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IConfiguration _configuration;
        private readonly MailSender _mailSender;


        public AccountService(IConfiguration configuration, IAccountRepository accountRepository, MailSender mailSender)
        {
            _configuration = configuration;
            _accountRepository = accountRepository;
            _mailSender = mailSender;
        }

        public async Task<ResponseModal> CreateUser(User user)
        {
            try
            {
                User? oldUser = await  _accountRepository.GetUserByMail(user.Email);
                if(oldUser == null)
                {
                  user = await _accountRepository.CreateUser(user);
                    return new ResponseModal { Data = user, Message = StatusConstant.SUCCESS, StatusCode = 200 };
                }
                else
                {
                    return new ResponseModal { Data = user, StatusCode= 200, Message = StatusConstant.USER_EXISTS };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModal { Data = null, StatusCode = 200, Message = ex.Message };
            }
        }

        public async Task<ResponseModal> CreateTenant(Tenant tenant)
        {
            try
            {
                tenant = await _accountRepository.CreateTenant(tenant);
                return new ResponseModal { Data = tenant, Message = StatusConstant.SUCCESS, StatusCode = 200 };
            }             
            catch (Exception ex) { 
                return new ResponseModal { Data = tenant, Message = ex.Message, StatusCode = 200 };
            }

        }

        public async Task<string> Login(AccountModal loginReq)
        {
            User? user = await _accountRepository.GetUserByMail(loginReq.Email);
            if (user != null)
            {
                if (user.Password != loginReq.Password)
                {
                    return StatusConstant.INVALID_PASSWORD;
                }
                else
                {
                    return GenerateToken(user);
                }
            }
            return StatusConstant.USER_NOT_EXISTS;
        }


        public async Task<ResponseModal> SendForgotPasswordMail(string email)
        {
           string result = await _mailSender.SendForgotPasswordLink(email);
            return new ResponseModal { Data = null, Message = result, StatusCode = 200 };
        }

        public async Task<ResponseModal> SendEmailVerificationMail(string email)
        {
            string result = await _mailSender.SendEmailVerificationLink(email);
            return new ResponseModal { Data = null, Message = result, StatusCode = 200 };
        }

        public async Task<ResponseModal> ChangePassword(string email, string password)
        {
            User user = await _accountRepository.GetUserByMail(email); 
            if (user != null)
            {
                user.Password = password;
                user.ModifiedOn = DateTime.Now;
                await _accountRepository.UpdateUser(user);
                return new ResponseModal { Data = user, Message = StatusConstant.SUCCESS, StatusCode = 200 };
            }
            else
            {
                return new ResponseModal { Data = user, Message= StatusConstant.USER_NOT_EXISTS, StatusCode= 200 };
            }
        }

        public async Task<ResponseModal> ChangeEmailVerifiedStatus(string email)
        {
            User user = await _accountRepository.GetUserByMail(email);
            if (user != null)
            {
                user.IsEmailVerified = true;
                user.ModifiedOn = DateTime.Now;
                await _accountRepository.UpdateUser(user);
                return new ResponseModal { Data = user, Message = StatusConstant.SUCCESS, StatusCode = 200 };
            }
            else
            {
                return new ResponseModal { Data = user, Message = StatusConstant.USER_NOT_EXISTS, StatusCode = 200 };
            }
        }
        private string GenerateToken(User? user)
        {
            if (user==null)
            {
                return "";
            }
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = Encoding.ASCII.GetBytes
            (_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.UserType),
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)                
             }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }

        public async Task<ResponseModal> GetAllUsers()
        {
            var users=await _accountRepository.GetAllUsers();

            return new ResponseModal { Data= users,Message=StatusConstant.SUCCESS,StatusCode=200 };
        }
        public async Task<ResponseModal> GetTenantUsers(Guid tenantId)
        {
            var users=await _accountRepository.GetTenantUsers(tenantId);

            return new ResponseModal { Data= users,Message=StatusConstant.SUCCESS,StatusCode=200 };
        }
    }
  
}