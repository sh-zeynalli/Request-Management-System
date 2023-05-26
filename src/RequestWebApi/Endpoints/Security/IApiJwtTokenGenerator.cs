using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestWebApi.Endpoints.Security;

public interface IApiJwtTokenGenerator
{
    Task<string> GenerateToken(string userId, string username, uint? expireMinutes = null);
}
