using HepsiBuraApi.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuraApi.Application.Interface.Token
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> CreateToken(User user, IList<string> roles); // Kullanıcı ve roller ile JWT token oluşturur.

        string GenerateRefreshToken(); // Yeni bir refresh token oluşturur.

        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);// Token'ın süresi dolmuşsa, token'dan ClaimsPrincipal oluşturur.
    }
}
