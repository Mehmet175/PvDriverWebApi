using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using PvDriver.Ef;
using PvDriver.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace PvDriver.Utils
{
    public class JwtUtil
    {
        public static string TokenCreate(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(AppConstants.JwtKey);
            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, user.RolId.ToString()),
                    new Claim(ClaimTypes.Authentication, user.Id.ToString()),
                    new Claim(ClaimTypes.AuthenticationInstant, user.CompanyId.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(365),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }

        public static JwtInfo GetUserInfo(HttpRequest request)
        {
            try
            {
                var token = request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes(AppConstants.JwtKey);
                var validationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(tokenKey),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
                SecurityToken securityToken;
                var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);


                var userId = claimsPrincipal.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Authentication)?.Value;
                var rolId = claimsPrincipal.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Role)?.Value;
                var userName = claimsPrincipal.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name)?.Value;
                var companyId = claimsPrincipal.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.AuthenticationInstant)?.Value;

                return new JwtInfo()
                {
                    UserId = userId == "" ? null : Guid.Parse(userId),
                    RolId = rolId == "" ? RolEnum.Single : (RolEnum)(int.Parse(rolId)),
                    UserName = userName,
                    CompanyId = companyId == "" ? null : Guid.Parse(companyId),
                };
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
