using System.Text;
using GeoObservables.Api.Aplication.Contracts.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using GeoObservables.Api.Aplication.Contracts.Models;

namespace GeoObservables.Api.Aplication.Login
{
    public class JwtHandler
    {

        private readonly IAppConfig _appConfig;
        public JwtHandler(IAppConfig appConfig)
        {
            _appConfig = appConfig;
        }

        public TokenResource CreateAccessToken(string email)
        {
            var now = DateTime.UtcNow;
            var claims = new[]
               {
                    new Claim(JwtRegisteredClaimNames.Sub, _appConfig.JwtSubject),
                    new Claim(JwtRegisteredClaimNames.Iss, _appConfig.JwtIssuer),
                    new Claim(JwtRegisteredClaimNames.Aud, _appConfig.JwtAudience),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),                    
                    //new Claim(ClaimTypes.NameIdentifier, user.Name),
                    new Claim(ClaimTypes.Email, email)
                };

            var expiry = now.AddMinutes(double.Parse(_appConfig.ExpireToken));

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appConfig.JwtKey)), SecurityAlgorithms.HmacSha256);

            var jwt = CreateSecurityToken(claims, now, expiry, signingCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            var baseDate = new DateTime(1970, 01, 01);

            var toTimeStamp = Convert.ToInt64(expiry.Subtract(baseDate).TotalSeconds);


            return CreateTokenResource(token, toTimeStamp);

        }

        public TokenResource CreateRefreshToken(Guid userId)
        {
            var now = DateTime.UtcNow;
            var claims = new Claim[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(), ClaimValueTypes.Integer64),
            };

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appConfig.JwtKey)),
                SecurityAlgorithms.HmacSha256);
            var expiry = now.AddMinutes(double.Parse(_appConfig.ExpireToken)); ;
            var jwt = CreateSecurityToken(claims, now, expiry, signingCredentials);
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            var baseDate = new DateTime(1970, 01, 01);
            var toTimeStamp = Convert.ToInt64(expiry.Subtract(baseDate).TotalSeconds);
            return CreateTokenResource(token, toTimeStamp);
        }

        private JwtSecurityToken CreateSecurityToken(IEnumerable<Claim> claims, DateTime now, DateTime expiry, SigningCredentials credentials)
            => new JwtSecurityToken(claims: claims, notBefore: now, expires: expiry, signingCredentials: credentials);

        private static TokenResource CreateTokenResource(string token, long expiry)
            => new TokenResource { Token = token, Expiry = expiry };
    }
}
