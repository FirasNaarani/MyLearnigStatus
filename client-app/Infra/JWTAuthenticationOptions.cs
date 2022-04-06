using LearnSchoolApp.Entities;
using LearnSchoolApp.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace node.Infra
{
    public interface IJWTAuthenticationOptions
    {
        string prepareAuthenticationToken(UpdateUser user);
    }

    public class JWTAuthenticationOptions : IJWTAuthenticationOptions
    {
        private readonly string tokenKey;

        public JWTAuthenticationOptions(string tokenKey)
        {
            this.tokenKey = tokenKey;
        }

        public string prepareAuthenticationToken(UpdateUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenKey);
            var claims = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.username),
                    new Claim(ClaimTypes.SerialNumber, user.userId),
                    new Claim(ClaimTypes.Email, user.email),
                    new Claim(ClaimTypes.Name, user.name),
                    new Claim(ClaimTypes.Role, user.userType.ToString())

            });
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
