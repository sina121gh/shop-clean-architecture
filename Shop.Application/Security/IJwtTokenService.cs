using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Security
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user, string userSecretCode);
    }
}
