using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momentum.Framework.Core.Services
{
    public interface IJwtService
    {
        Task<string> GenerateRefreshTokenAsync(Guid userId, bool gameRequest);
        string GenerateAccessToken(Guid userId, ulong steamId, int roles, int bans, bool gameRequest);
        Task<string> RefreshAccessTokenAsync(Guid userId, string refreshToken, ulong steamId, int roles, int bans, bool gameRequest);
        bool VerifyAccessToken(string accessToken);
        Task RevokeRefreshTokenAsync(Guid userId);

    }

}
