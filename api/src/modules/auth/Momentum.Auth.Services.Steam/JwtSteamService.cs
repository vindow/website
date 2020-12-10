using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Momentum.Framework.Core.Services;
using Momentum.Users.Application.Handlers.Queries;

namespace Momentum.Auth.Services.Steam
{
    /// <summary>
    /// TODO: the token still has to be refreshed
    /// </summary>
    public class JwtSteamService : IJwtService
    {
        private readonly IConfiguration m_configuration;
        private readonly IMediator m_mediator;
        public JwtSteamService(IConfiguration configuration, IMediator mediator) //, AuthenticationDbContext authenticationDbContext)
        {
            m_configuration = configuration;
            m_mediator = mediator;
        }

        /// <summary>
        /// Generates a refresh token for a user, then either adds a new entry to the DB, or updates the existing one.
        /// </summary>
        /// <param name="userId">Momentum Mod user ID</param>
        /// <param name="gameRequest">If the request comes from the game then `true` otherwise `false`</param>
        /// <returns>The encoded refresh token</returns>
        public async Task<string> GenerateRefreshTokenAsync(Guid userId, bool gameRequest)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(m_configuration["JWT_KEY"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(m_configuration["JWT_ISSUER"],
                claims: new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString())
                },
                signingCredentials: credentials);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            await m_mediator.Publish(new Framework.Core.Events.UserEvents.UserTokenRefreshedEvent()
            {
                IssuedAt = token.IssuedAt,
                RefreshToken = tokenString,
                UserId = userId
            });

            return tokenString;
        }
        public string GenerateAccessToken(Guid userId, ulong steamId, int roles, int bans, bool gameRequest)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(m_configuration["JWT_KEY"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(m_configuration["JWT_ISSUER"],
                claims: new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                    new Claim("steamID", steamId.ToString()),
                    new Claim("roles", roles.ToString()),
                    new Claim("bans", bans.ToString()),
                    new Claim("gameAuth", gameRequest.ToString()),
                },
                signingCredentials: credentials,
                expires: new DateTime(0, 0, 0, 0, gameRequest ? m_configuration.GetValue<int>("JWT_EXPIRE_TIME")
                    : m_configuration.GetValue<int>("JWT_GAME_EXPIRE_TIME"), 0));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> RefreshAccessTokenAsync(Guid userId, string refreshToken, ulong steamId, int roles, int bans, bool gameRequest)
        {
            var user = await m_mediator.Send(new UserById() { UserId = userId, Expand = false });

            if (user.RefreshToken != refreshToken)
            {
                return null;
            }

            return GenerateAccessToken(userId, steamId, roles, bans, gameRequest);
        }

        public bool VerifyAccessToken(string accessToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(m_configuration["JWT_KEY"]))
            };

            SecurityToken validatedToken;

            try
            {
                tokenHandler.ValidateToken(accessToken, validationParameters, out validatedToken);
            }
            catch (Exception)
            {
                return false;
            }

            return validatedToken != null;
        }

        public async Task RevokeRefreshTokenAsync(Guid userId)
        {
            await m_mediator.Publish(new Framework.Core.Events.UserEvents.UserTokenRevokedEvent()
            {
                UserId = userId
            });
        }
    }
}
