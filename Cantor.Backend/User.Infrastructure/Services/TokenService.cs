using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using User.Application.Services;

namespace User.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private const string MySecret = "asdv234234^&%&^%&^hjsdfb2%%%";
        public string GenerateToken(Guid ownerId)
        {
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(MySecret));
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, ownerId.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}