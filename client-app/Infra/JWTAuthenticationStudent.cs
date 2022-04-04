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
    public interface IJWTAuthenticationStudent
    {
        string prepareAuthenticationToken(string username, string userType);
    }

    public class JWTAuthenticationStudent : IJWTAuthenticationStudent
    {
        private readonly string tokenKey;

        public JWTAuthenticationStudent(string tokenKey)
        {
            this.tokenKey = tokenKey;
        }

        public string prepareAuthenticationToken(string username, string userType)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenKey);
            var id = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, userType)

            });
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = id,
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
