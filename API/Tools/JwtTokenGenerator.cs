using DTO.DTOS.TokenDTO;
using DTO.DTOS.UsersDTO.LoginDTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseDTO GenerateToken(LoginUserDTO dto)
        {
            var claims=new List<Claim>();
            if (!string.IsNullOrEmpty(dto.EmailOrUserName))
            {
                claims.Add(new Claim("EmailOrUserName", dto.EmailOrUserName));          
            }
           var key =new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
            var signInCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expireDate = DateTime.UtcNow.AddMinutes(JwtTokenDefaults.ExpireTime);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
               issuer: JwtTokenDefaults.ValidIssuer,
               audience: JwtTokenDefaults.ValidAudience,
               claims: claims,
               notBefore:DateTime.UtcNow,
               expires:expireDate,
               signingCredentials:signInCredentials
                );
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return new TokenResponseDTO(handler.WriteToken(jwtSecurityToken),expireDate);
        }
    }
}
