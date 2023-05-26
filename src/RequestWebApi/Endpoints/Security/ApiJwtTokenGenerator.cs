using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace RequestWebApi.Endpoints.Security;

public class ApiJwtTokenGenerator : IApiJwtTokenGenerator
{
    private readonly JwtIssuerOptions jwtOptions;

    public ApiJwtTokenGenerator(IOptions<JwtIssuerOptions> jwtOptions) => this.jwtOptions = jwtOptions.Value;

    public async Task<string> GenerateToken(string userId, string username, uint? expireMinutes = null)
    {
        var header = new JwtHeader(jwtOptions.SigningCredentials);

        Claim[] claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(JwtRegisteredClaimNames.UniqueName, username),
                new Claim(JwtRegisteredClaimNames.Iss, jwtOptions.Issuer),
                new Claim(JwtRegisteredClaimNames.Aud, jwtOptions.Audience),
                new Claim(JwtRegisteredClaimNames.Exp,
                (expireMinutes.HasValue ? new DateTimeOffset(jwtOptions.IssuedAt.AddMinutes((double)expireMinutes)) :
                new DateTimeOffset(jwtOptions.Expiration))
                .ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
        };

        var payload = new JwtPayload(claims);
        var jwt = new JwtSecurityToken(header, payload);

        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        return encodedJwt;
    }
}
