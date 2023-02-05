using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace NewsPortal.WebApi.Infrastructure.AuthOptions
{
    public class JwtAuthManager
    {
        private readonly JwtTokenConfig _jwtTokenConfig;

        /// <summary>
        /// Initialize <see cref="JwtAuthManager"/>.
        /// </summary>
        /// <param name="jwtTokenConfig">Configuration for jwt token.</param>
        public JwtAuthManager(JwtTokenConfig jwtTokenConfig)
        {
            _jwtTokenConfig = jwtTokenConfig;
        }

        /// <summary>
        /// Generates access token by claims.
        /// </summary>
        /// <param name="claims">Set of claims.</param>
        /// <param name="now">Time stamp for access token lifetime.</param>
        public JwtAuthResult GenerateAccessToken(Claim[] claims, DateTime now)
        {
            var shouldAddAudienceClaim = string.IsNullOrWhiteSpace(claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);
            var jwtToken = new JwtSecurityToken(
                _jwtTokenConfig.Issuer,
                shouldAddAudienceClaim ? _jwtTokenConfig.Audience : string.Empty,
                claims,
                expires: now.AddMinutes(_jwtTokenConfig.TokenLifeTime),
                signingCredentials: new SigningCredentials(_jwtTokenConfig.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return new JwtAuthResult
            {
                AccessToken = accessToken
            };
        }

        public string GenerateRefreshToken(DateTime now)
        {
            var jwtToken = new JwtSecurityToken(
                expires: now,
                signingCredentials: new SigningCredentials(_jwtTokenConfig.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature));
            var refresh = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return refresh;
        }
    }

    public class JwtAuthResult
    {
        public string AccessToken { get; set; }
    }
    
}
