using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tmdb.Core.Options;

namespace Tmdb.Services.Token
{
    public class TokenGeneretor : ITokenGenerator
    {
        private readonly SettingsJWTOptions _configuration;
        public TokenGeneretor(IOptions<SettingsJWTOptions> configuracaoJWTOptions)
        {
            _configuration = configuracaoJWTOptions.Value;
        }

        public string GenerateToken(string userName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_configuration.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,userName),
                    new Claim(ClaimTypes.Role, "User")
                }),
                Expires = DateTime.UtcNow.AddHours(_configuration.HoursToExpire),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
