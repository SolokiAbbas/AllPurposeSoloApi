using AllPurpose.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AllPurpose.Logic
{
    public class JwtHandler: IJwtHandler
    {
        private TokenValidationParameters DefaultTokenValidationParameters { get; }
        private int TokenLifetime { get; }
        private AllPurpOptions Options { get; }
        public JwtHandler(IOptions<AllPurpOptions> options)
        {
            Options = options.Value;
            var secret = Options.JwtSecret;
            TokenLifetime = 3600;
            var bytes = Encoding.Unicode.GetBytes(secret);
            var randomKey = new SymmetricSecurityKey(bytes);
            DefaultTokenValidationParameters = new TokenValidationParameters()
            {
                ValidAudience = "Any",
                ValidIssuer = "Any",
                IssuerSigningKey = randomKey,
                ValidateAudience = true,
                ValidateIssuer = true
            };
        }

        public bool ValidateJwt(string encodedJwt)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                handler.ValidateToken(encodedJwt, DefaultTokenValidationParameters, out SecurityToken validatedToken);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public string GenerateJwt()
        {
            var securityKey = DefaultTokenValidationParameters.IssuerSigningKey;
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
            var issuer = DefaultTokenValidationParameters.ValidIssuer;
            var audience = DefaultTokenValidationParameters.ValidAudience;
            var claim = new Claim[]
                { new Claim("Role", "User") };
            var jwt = new JwtSecurityToken(issuer, audience, claim, DateTime.UtcNow, DateTime.UtcNow.AddSeconds(TokenLifetime), credentials);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }
    }
}
