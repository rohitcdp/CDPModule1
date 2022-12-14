using CDPModule1.Server.Authentication;
using CDPModule1.Server.IRepository;
using CDPModule1.Server.IServices;
using CDPModule1.Server.Repository;
using CDPModule1.Server.Utils;
using CDPModule1.Shared;
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

        public AccountService(IConfiguration configuration, IAccountRepository accountRepository)
        {
            _configuration = configuration;
            _accountRepository = accountRepository;
        }

        public string Register(Tenant user)
        {
            string result =_accountRepository.Register(user);
            return result.Equals(StatusConstant.SUCCESS) ? GenerateToken(user) : result;
        }

        public string Login(Tenant user)
        {
            Tenant? olduser =  _accountRepository.GetUserByMail(user.Email);
            if (olduser != null)
            {
                if (olduser.Password != user.Password)
                {
                    return StatusConstant.INVALID_PASSWORD;
                }
                else
                {
                    return GenerateToken(olduser);
                }
            }
            return StatusConstant.USER_NOT_EXISTS;
        }

        private string GenerateToken(Tenant? user)
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
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, user.UserType),
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
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
    }
  
}