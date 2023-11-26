using Domain.Utils.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model.Dto;
using Model.Entities;
using Model.Enum;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Domain.Utils
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenDto GenerateAccessToken(User user)
        {

            int minutes = Convert.ToInt32(_configuration.GetSection("AccessTokenExpiryMinutes").Value);
            var configKey = _configuration.GetSection("AccessToken").Value;
            RoleEnum role = user.IsAdmin ? RoleEnum.Admin : RoleEnum.User;

            var claims = new List<Claim>
            {
                new Claim("id", user.Id),
                new Claim("name", user.Name),
                new Claim("email", user.Email),
                new Claim("expration", DateTime.Now.AddMinutes(minutes).ToString()),
                new Claim("role", role.ToString()) 
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configKey));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(minutes),
                signingCredentials: signingCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return new TokenDto(tokenString, minutes * 60 * 1000);
        }
    }
}
